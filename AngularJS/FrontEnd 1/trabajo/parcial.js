/**

Se solicita hacer un sistema de gestión y seguimiento de pedidos.
El servidor entrega a através de una API los pedidos y los tems que tiene almacenados.
El front-end deberá recuperar esos pedidos e ítems, mostrándolos en el lugar correspondiente de la vista (_vista.html).
El servidor no guarda datos nuevos, por lo cual los pedidos nuevos se almacenarán en el local-storage y se perderán al recargar la página.
Las URLs de la API para obtener pedidos e ítems son (respectivamente)
- api/pedidos
- api/items
Sobre éstos deberán realizarse las peticiones ajax correspondientes para obtener los datos.

La vista (archivo "_vista.html") consta de 3 partes:
1- Listado de pedidos y sus estados

2- La modificación del estado de los pedidos (botones de la columna "cambio de estado"). Al hacer clic en los respectivos botones, deberá
modificarse el estado del pedido. Los estados posibles son Pendiente, Entregado y Cancelado. Cuando se crea un nuevo pedido, debe hacerse en 
estado Pendiente. Cada pedido solicitado a la API viene acompañado de un campo estado booleano que indica su estado:
 - estadoPendiente
 - estadoEntregado
 - estadoCancelado
Solo uno de esos campos podrá estar en true. El resto será false o null.

3- Formulario de pedidos (contiene la lista de todos los ítems para seleccionar) y otros datos del pedido
Se proveen datos estáticos a modo de ejemplo, los cuales deben reemplazarse por las directivas AngularJS necesarias para darle funcionalidad 
al sistema. Los únicos archivos que pueden editarse son los que están en la carpeta "trabajo". Los demás pueden verse pero no modificarse.
Procuren no romper el html.


En resúmen, los puntos a resolver son los siguientes:
1- Vista de la "Gestión de pedidos". Mostrar la etiqueta de estado correspondiente y los botones de cambio de estado que tengan sentido, es decir,
si el estado es Pendiente, ocultar el botón de cambio de estado "Pasar a pendiente" y de la misma manera para los otros estados.
2- Creación de un pedido (crearlo en estado "Pendiente").
3- Edición de un pedido (mantener el estado del pedido sin alteraciones).
4- Borrado de un pedido.
5- Cambio de estado de un pedido
Para aprobar, es necesario resolver correctamente el punto 1 y al menos, tres de los cuatro puntos restantes (2, 3, 4 y 5).

Al finalizar, comprimir la carpeta "trabajo", poner el apellido como nombre de archivo y adjuntarla en el link del campus virtual correspondiente.
Se evaluará UNICAMENTE la carpeta "trabajo", no considerándose las modificaciones que se hagan en los demás archivos.

*/

angular.module('parcialApp', []).controller('parcialCtrl', function($scope, $http, $filter) {

	$scope.nuevoPedido = {};
	$scope.copiaPedido = {};
	
	$http.get('api/pedidos')
		.then(function(resp) {
			$scope.pedidos = resp.data;
		})
		.catch(function(resp) {
			$scope.pedidos = {};
		});

	$http.get('api/items')
		.then(function(resp) {
			$scope.items = resp.data;
		})
		.catch(function(resp) {
			$scope.items = {};
		});
	$scope.guardarPedido = function (){
		if($scope.nuevoPedido.editando)
		{
			var x = $filter('filter')($scope.pedidos, {editando: true});
			$scope.pedidos.splice($scope.pedidos.indexOf(x[0]), 1);
		}
		else
		{
			$scope.nuevoPedido.estadoPendiente = true;
		}
		$scope.pedidos.push($scope.nuevoPedido);
		$scope.nuevoPedido = {};
	}
	$scope.descartarPedido = function(){
		if($scope.nuevoPedido.editando)
		{
			var x = $filter('filter')($scope.pedidos, {editando: true});
			x[0].editando = null;
		}
		$scope.nuevoPedido = {};
	}
	$scope.editarPedido = function (p){
		p.editando = true;
		$scope.nuevoPedido = angular.copy(p);
	}
	$scope.borrarPedido = function (p){
		$scope.pedidos.splice($scope.pedidos.indexOf(p), 1);
	}
	$scope.pasarEntregado = function (p){		
		
		$scope.copiaPedido = angular.copy(p);

		if($scope.copiaPedido.estadoPendiente)
		{
			$scope.copiaPedido.estadoPendiente = null;
			$scope.copiaPedido.estadoEntregado = true;
		}
		else
		{
			$scope.copiaPedido.estadoCancelado = null;
			$scope.copiaPedido.estadoEntregado = true;
		}
		$scope.pedidos.splice($scope.pedidos.indexOf(p), 1, $scope.copiaPedido);
	}
	$scope.pasarCancelado = function (p){
		$scope.copiaPedido = angular.copy(p);

		if($scope.copiaPedido.estadoPendiente)
		{
			$scope.copiaPedido.estadoPendiente = null;
			$scope.copiaPedido.estadoCancelado = true;
		}
		else
		{
			$scope.copiaPedido.estadoEntregado = null;
			$scope.copiaPedido.estadoCancelado = true;
		}
		$scope.pedidos.splice($scope.pedidos.indexOf(p), 1, $scope.copiaPedido);
	}
	$scope.pasarPendiente = function (p){
		$scope.copiaPedido = angular.copy(p);

		if($scope.copiaPedido.estadoCancelado)
		{
			$scope.copiaPedido.estadoCancelado = null;
			$scope.copiaPedido.estadoPendiente = true;
		}
		else
		{
			$scope.copiaPedido.estadoEntregado = null;
			$scope.copiaPedido.estadoPendiente = true;
		}
		$scope.pedidos.splice($scope.pedidos.indexOf(p), 1, $scope.copiaPedido);
	}
});
