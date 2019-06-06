<?php
$command = explode('/',strtolower($_GET['accion']));

switch($command[0])
{
	case 'pedidos':
		header('Content-Type: application/json; charset=utf-8');
		$datos=[];
		$datos[] = [
			'id'				=> 1,
			'cliente'			=> 'Peter Cantropus',
			'domicilio'			=> 'Cucha Cucha 3451 - 1ºB - CABA',
			'estadoPendiente'	=> true,
			'items'				=> [
				['id' => 1, 'detalle' => 'Fuente 12v 2a - 220v'],
				['id' => 2, 'detalle' => 'Tira led 5050 blanco frío'],
				['id' => 3, 'detalle' => 'Cable bipolar 2x2mm x 10mts'],
				['id' => 9, 'detalle' => 'Perfil angular aluminio 1 metro'],
			]
		];
		$datos[] = [
			'id'				=> 2,
			'cliente'			=> 'Mila Nessa',
			'domicilio'			=> 'Tres sargentos 2566- PB - CABA',
			'estadoPendiente'	=> true,
			'items'				=> [
				['id' => 5, 'detalle' => 'Fuente 12v 5a - 220v'],
				['id' => 6, 'detalle' => 'Perfil de aluminio 1 metro'],
				['id' => 8, 'detalle' => 'Soportes con tornillo x 2u'],
			]
		];
		$datos[] = [
			'id'				=> 3,
			'cliente'			=> 'Cindy Nero',
			'domicilio'			=> 'Olavarría 2389 - Mar del Plata',
			'estadoEntregado'	=> true,
			'items'				=> [
				['id' => 4, 'detalle' => 'Cargador USB para auto 2a'],
				['id' => 7, 'detalle' => 'Conector 12v macho a bornera'],
			]
		];
		
		$datos[] = [
			'id'				=> 4,
			'cliente'			=> 'Jorge Latina',
			'domicilio'			=> 'Av. Gral. San Martín 1776 - 12º A - Salta',
			'estadoCancelado'	=> true,
			'items'				=> [
				['id' => 7, 'detalle' => 'Conector 12v macho a bornera'],
			]
		];
		print json_encode($datos);
		break;

	case 'items':
		header('Content-Type: application/json; charset=utf-8');
		$datos=[
			['id' => 1, 'detalle' => 'Fuente 12v 2a - 220v'],
			['id' => 2, 'detalle' => 'Tira led 5050 blanco frío'],
			['id' => 3, 'detalle' => 'Cable bipolar 2x2mm x 10mts'],
			['id' => 4, 'detalle' => 'Cargador USB para auto 2a'],
			['id' => 5, 'detalle' => 'Fuente 12v 5a - 220v'],
			['id' => 6, 'detalle' => 'Perfil de aluminio 1 metro'],
			['id' => 7, 'detalle' => 'Conector 12v macho a bornera'],
			['id' => 8, 'detalle' => 'Soportes con tornillo x 2u'],
			['id' => 9, 'detalle' => 'Perfil angular aluminio 1 metro'],
		];
		print json_encode($datos);
		break;

	default:
		header(' ', true, 404);
		die;
}
