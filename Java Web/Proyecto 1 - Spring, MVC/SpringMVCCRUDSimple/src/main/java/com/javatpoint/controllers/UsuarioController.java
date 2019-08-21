package com.javatpoint.controllers;   
import java.io.BufferedReader;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URI;
import java.security.Principal;
import java.util.Collection;
import java.util.Enumeration;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import javax.servlet.AsyncContext;
import javax.servlet.DispatcherType;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.ServletInputStream;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.servlet.http.HttpUpgradeHandler;
import javax.servlet.http.Part;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpRequest;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;  
import org.springframework.web.bind.annotation.PathVariable;  
import org.springframework.web.bind.annotation.RequestMapping;  
import org.springframework.web.bind.annotation.RequestMethod;

import com.javatpoint.beans.Producto;
import com.javatpoint.beans.Usuario;  
import com.javatpoint.dao.UsuarioDao;  
@Controller  
public class UsuarioController {  
	@Autowired 
	    UsuarioDao dao;//will inject dao from xml file  			     
	    /*It displays a form to input data, here "command" is a reserved request attribute 
	     *which is used to display object data into form 
	     */
	 	@RequestMapping("/contacto")  
	    public String mostrarContacto(Model m){  
	    	return "contacto"; 
	    } 
	 	@RequestMapping("/soporte")  
	    public String mostrarSoporte(Model m){  
	    	return "soporte"; 
	    } 
	 	@RequestMapping("/tienda")  
	    public String mostrarTienda(Model m){
	 		List<Producto> list = dao.getProductos();
	 		m.addAttribute("list", list);
	    	return "tienda"; 
	    }  
	 	
	 	@RequestMapping("/homepg")  
	    public String mostrarHomepg(Model m){  
	 		List<Usuario> list=dao.getUsuarios();  
	        m.addAttribute("list",list);
	    	return "homepg"; 
	    }  
	    @RequestMapping("/login")  
	    public String mostrarLogin(HttpServletRequest request, Model m){
	    	HttpSession sesion = request.getSession();
	    	if(sesion.getAttribute("nombre") != null)
	    		sesion.invalidate();
	    	m.addAttribute("command", new Usuario());
	    	return "login"; 
	    }  
	    /*It saves object into database. The @ModelAttribute puts request data 
	     *  into model object. You need to mention RequestMethod.POST method  
	     *  because default request is GET*/  
	    @RequestMapping(value="/save",method = RequestMethod.POST)  
	    public String save(@ModelAttribute("usr") Usuario usr){  	
	    	usr.setIsAdmin(false);
	        usr.setIsBloqueado(false);
	    	dao.save(usr);  
	        return "redirect:/login";//will redirect to login request mapping  
	    }  
	    /* It provides list of employees in model object */  
	    @RequestMapping("/viewusr")  
	    public String viewusr(Model m){  
	        List<Usuario> list=dao.getUsuarios();  
	        m.addAttribute("list",list);
	        return "viewusr";  
	    }  
	    /* It displays object data into form for the given id.  
	     * The @PathVariable puts URL data into variable.*/  
	    @RequestMapping(value="/editarusuario/{id}")  
	    public String editarUsuario(@PathVariable int id, Model m){  
	        Usuario usr = null;
	        for (Usuario usuario : dao.getUsuarios()) {
				if(usuario.getId() == id)
					usr = usuario;
			}
	        m.addAttribute("command",usr);
	        return "editarUsuario";  
	    }  
	    /* It updates model object. */  
	    @RequestMapping(value="/guardareditado",method = RequestMethod.POST)  
	    public String guardarEditado(@ModelAttribute("usr") Usuario usr, HttpServletRequest request){  
	        HttpSession sesion = request.getSession();
	    	dao.update(usr);
	        if(sesion.getAttribute("id").equals(usr.getId()))
	        {
	        	guardarSesion(request, usr.getId(), usr.getNombre(), usr.getClave(), usr.getEmail(), usr.getIsBloqueado(), usr.getIsAdmin());
	        }
	        return "redirect:/homepg";  
	    }  
	    /* It deletes record for the given id in URL and redirects to /viewusr */  
	    @RequestMapping(value="/deleteemp/{id}",method = RequestMethod.GET)  
	    public String delete(@PathVariable int id){  
	        dao.delete(id);  
	        return "redirect:/viewusr";  
	    }
	    @RequestMapping("/crearcuenta")  
	    public String crearCuenta(Model m){  
	    	m.addAttribute("command", new Usuario());
	    	return "crearcuenta"; 
	    }
	    @RequestMapping(value="/loguearusuario", method= RequestMethod.POST)  
	    public String loguearUsuario(@ModelAttribute("usr") Usuario usr, HttpServletRequest request){  
	    	HttpSession sesion = request.getSession();
			sesion.setAttribute("usuarioBloqueado", null);
			sesion.setAttribute("usuarioClave", null);
			sesion.setAttribute("usuarioNoExiste", null);
			
	    	for (Usuario usuario : dao.getUsuarios()) {
//				if(usuario.getNombre().equals(usr.getNombre()) && usuario.getClave().equals(usr.getClave()) && usuario.getIsBloqueado() != true){
//					guardarSesion(request, usuario.getId(), usuario.getNombre(), usuario.getClave(), usuario.getEmail(), usuario.getIsBloqueado(), usuario.getIsAdmin());
//					
//					return "redirect:/homepg";
//				}
	    		if(usuario.getNombre().equals(usr.getNombre()))
	    		{
	    			if(usuario.getIsBloqueado() != true)
	    			{
	    				if(usuario.getClave().equals(usr.getClave()))
	    				{
	    					guardarSesion(request, usuario.getId(), usuario.getNombre(), usuario.getClave(), usuario.getEmail(), usuario.getIsBloqueado(), usuario.getIsAdmin());
	    					
	    					return "redirect:/homepg";
	    				}
	    				else
	    				{
	    					sesion.setAttribute("usuarioClave", true);
		    				return "redirect:/login";
	    				}
	    			}
	    			else
	    			{    				
	    				sesion.setAttribute("usuarioBloqueado", true);
	    				return "redirect:/login";
	    			}
	    		}
			}
	    	sesion.setAttribute("usuarioNoExiste", true);
	    	return "redirect:/login"; 
	    }
	    @RequestMapping(value="/desbloquearusuario/{id}", method = RequestMethod.GET)  
	    public String desbloquear(@PathVariable int id, Model m){  
	        dao.desbloquearUsr(id);
	        return "redirect:/homepg";  
	    }
	    @RequestMapping(value="/bloquearusuario/{id}", method = RequestMethod.GET)  
	    public String bloquear(@PathVariable int id, Model m){  
	        dao.bloquearUsr(id);
	        return "redirect:/homepg";  
	    }  
	    
	    private void guardarSesion(HttpServletRequest request,int id, String nombre, String clave, String email,Boolean estaBloqueado, Boolean esAdmin) {
			HttpSession sesion = request.getSession();
			sesion.setAttribute("id", id);
			sesion.setAttribute("nombre", nombre);
			sesion.setAttribute("clave", clave);
			sesion.setAttribute("email", email);
			sesion.setAttribute("estaBloqueado", estaBloqueado);
			sesion.setAttribute("esAdmin", esAdmin);
			sesion.setMaxInactiveInterval(5*60);
		}
}