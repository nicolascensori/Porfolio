package com.javatpoint.dao;  
import java.sql.ResultSet;  
import java.sql.SQLException;  
import java.util.List;  
import org.springframework.jdbc.core.BeanPropertyRowMapper;  
import org.springframework.jdbc.core.JdbcTemplate;  
import org.springframework.jdbc.core.RowMapper;  
import com.javatpoint.beans.Usuario;
import com.javatpoint.beans.Producto;
  
public class UsuarioDao {  
	JdbcTemplate template;

	public void setTemplate(JdbcTemplate template) {
		this.template = template;
	}  

	public int save(Usuario u){
		int estaBloqueado;
		int esAdmin;
		
		if(u.getIsBloqueado())
			estaBloqueado = 1;
		else
			estaBloqueado = 0;
		
		if(u.getIsAdmin())
			esAdmin = 1;
		else
			esAdmin = 0;
		
	    String sql="insert into usuario(nombre,clave,email,estaBloqueado,esAdmin) values('"+u.getNombre()+"','"+u.getClave()+"','"+u.getEmail()+"',"+estaBloqueado+",'"+esAdmin+"')";  
	    return template.update(sql);
	}  
	public int update(Usuario u){  
		int estaBloqueado;
		int esAdmin;
		
		if(u.getIsBloqueado())
			estaBloqueado = 1;
		else
			estaBloqueado = 0;
		
		if(u.getIsAdmin())
			esAdmin = 1;
		else
			esAdmin = 0;
	    String sql="UPDATE `usuario` SET `nombre` = '"+u.getNombre()+"', `clave` = '"+u.getClave()+"', `email` = '"+u.getEmail()+"', `estaBloqueado` = '"+estaBloqueado+"', `esAdmin` = '"+esAdmin+"' WHERE `usuario`.`id` ="+u.getId()+"";  
	    return template.update(sql);  
	}  
	public int delete(int id){  
	    String sql="delete from usuario where id="+id+"";  
	    return template.update(sql);  
	}  
	public Usuario getUsuarioById(int id){  
	    String sql="select * from usuario where id=?";  
	    return template.queryForObject(sql, new Object[]{id},new BeanPropertyRowMapper<Usuario>(Usuario.class));  
	}
	
	public int desbloquearUsr(int id){
		
		String sql = "UPDATE `usuario` SET `estaBloqueado` = '0' WHERE `usuario`.`id` ="+id+"";
		return template.update(sql);
	}
	public int bloquearUsr(int id){
		
		String sql = "UPDATE `usuario` SET `estaBloqueado` = '1' WHERE `usuario`.`id` ="+id+"";
		return template.update(sql);
	}
	public List<Usuario> getUsuarios(){  
	    return template.query("select * from usuario",new RowMapper<Usuario>(){  
	        public Usuario mapRow(ResultSet rs, int row) throws SQLException {  
	            Usuario usr = new Usuario();  
	            usr.setId(rs.getInt(1));  
	            usr.setNombre(rs.getString(2));
	            usr.setClave(rs.getString(3));
	            usr.setEmail(rs.getString(4));
	            usr.setIsBloqueado(rs.getBoolean(5));  
	            usr.setIsAdmin(rs.getBoolean(6)); 
	            return usr;  
	        }  
	    });  
	}
	public List<Producto> getProductos(){  
	    return template.query("select * from producto",new RowMapper<Producto>(){  
	        public Producto mapRow(ResultSet rs, int row) throws SQLException {  
	            Producto prod = new Producto();           
	            prod.setId(rs.getInt(1));  
	            prod.setNombre(rs.getString(2));
	            prod.setDescripcion(rs.getString(3));
	            prod.setPrecio(rs.getDouble(4));
	            prod.setFoto(rs.getString(5));  
	            prod.setIdUsuario(rs.getInt(6)); 
	            return prod;  
	        }  
	    });  
	}
}  