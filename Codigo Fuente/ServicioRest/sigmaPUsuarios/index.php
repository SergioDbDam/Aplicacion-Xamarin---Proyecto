<?php
/**
 * Este servicio está operativo en 
 * 
 * https://ieslamarisma.net/profesores/santi/rest/srvprov
 * 
 * Dispone de los métodos
 *   /provincias            (GET)
 *   /provincia             (POST)
 *   /provincia/{id}        (GET | PUT | DELETE)
 *   /provincia/cod/{cod}   (GET)
 * 
 */


// Incluimos autocargador de ficheros de framework y bibliotecas instaladas
// con somposer
include __DIR__ . "/vendor/autoload.php";
include __DIR__ . '/modelo/Provincia_DBHelper.php';

/**
 * Slim y los frameworks modernos Simphony, Laravel, ... utiliza un enfoque 
 * similar al que se utilza en JEE. Una petición en HTTP se modela con
 * dos objetos
 * request -> Objeto que guarda atributos de la petición
 * response -> Objeto que guarda atributos de la respuesta
 * 
 * Nosotros deberemos evaluar la petición y generar la respuesta, que ya
 * recibimos creada en nuestra función.
 * 
 * En Slim, las ultimas versiones, cumplen la especificación PSR7
 * https://www.php-fig.org/psr/psr-7/
 * Esto hace que el objeto 'response' sea inmutable y no podamos hacer cambios
 * sobre el. Para hacer cambios lo que haremos será modificar el objeto con
 * sus métodos y crear un nuevo objeto
 */
// Objetos que gestionan petición y respuesta en Slim
use \Psr\Http\Message\ServerRequestInterface as Request;
use \Psr\Http\Message\ResponseInterface as Response;
// Codigo para llevar un log de las operaciones realizadas
// Todas las peticiones realizadas sobre el servicio se anotarán en el fichero
// service.log ubicado en la misma carpeta que el fichero php
use Monolog\Logger;
use Monolog\Handler\StreamHandler;

///////////////////////////////////////////////////////////////////////////////
///   CODIGO QUE EVALUA LAS PETICIONES
///////////////////////////////////////////////////////////////////////////////
// Creamos Framework
$app = new \Slim\App(['debug'=>true]);



// Mecanismo que tiene el Framework para compartir variables entre los métodos
$container = $app->getContainer();
$container["logger"] = function ($c) { // Funcion anonima en PHP
    // create a log channel
    $log = new Logger("api");
    $filename = __DIR__ . '/logs/service.log';
    $stream = new Monolog\Handler\StreamHandler($filename, Monolog\Logger::DEBUG);
    $log->pushHandler($stream);
            
    return $log;
};


$db_prov = new Provincia_DBHelper();
$db_prov->setLogger($app->getContainer()->logger);

//
// Definimos rutas que gestionará nuestro servicio
// las rutas tendran la forma http://servidor/(carpeta_proyecto)/XXX[/YYYY[/ZZZ..]]]
// 
// GET provincias
// Deuelve el listado de todas las provincias
// Atiende petición http://servidor/(carpeta_proyecto)/provincias
$app->get('/registros', function (Request $request, Response $response, array $args) use($db_prov) {
    $this["logger"]->debug('GET /registros');

    try {
        return $response->withJson($db_prov->getAll());
    } catch (Exception $e) {
        $this["logger"]->error("Error: {$e->getMessage()}");
        return $response->withJson([
                    'error' => 1,
                    'desc' => 'Error procesando petición' . $e->getMessage()], 400);
        // Véase códigos de error https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP
    }
});

/**
 * GET provincia/id
 * Deuelve información de una provincia referenciada por el indice id
 */
$app->get('/objetivo/{id}', function (Request $request, Response $response, array $args) use($db_prov) {
    $id = $args['id'];
    $this["logger"]->debug('GET /objetivo/' . $id);

    try {
        $objetivo = $db_prov->get($id);
    } catch (Exception $e) {
        $this["logger"]->error("Error: {$e->getMessage()}");
        return $response->withJson([
                    'error' => 1,
                    'desc' => 'Error procesando petición' . $e->getMessage()], 400);
        // Véase códigos de error https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP
    }
    if ($objetivo) {
        // Existe la provincia devolvemos su valor
        return $response->withJson($db_prov->get($id));
    } else {
        // No existe el elemento, devolvemos código 404
        return $response->withJson([], 404);
    }
});

/**
 * GET provincia/cod/uncodigo
 * Deuelve información de una provincia referenciada por el indice id
 */
$app->get('/objetivo/cod/{cod}', function (Request $request, Response $response, array $args) use($db_prov) {
    $cod = $args['cod'];
    $this["logger"]->debug('GET /objetivo/cod/' . $cod);

    try {
        $objetivo = $db_prov->getByCod($cod);
    } catch (Exception $e) {
        $this["logger"]->error("Error: {$e->getMessage()}");
        return $response->withJson([
                    'error' => 1,
                    'desc' => 'Error procesando petición ' . $e->getMessage()], 400);
        // Véase códigos de error https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP
    }

    if ($objetivo) {
        // Existe la provincia devolvemos su valor
        return $response->withJson($provincia);
    } else {
        // No existe el elemento, devolvemos código 404
        return $response->withJson([], 404);
    }
});


/**
 * POST provincia/id
 * Inserta una nueva provincia
 */
$app->post('/objetivo', function (Request $request, Response $response, array $args) use($db_prov) {
    $this["logger"]->debug('POST /objetivo');

    $datos_post = $request->getParsedBody();
    $this["logger"]->debug('POST-DATOS ' . print_r($datos_post, true));

    if (Objetivos::isValidFromArray($datos_post)) {
        $objetivo = Objetivos::LoadFromArray($datos_post);
        try {
            $ok = $db_prov->add($objetivo);
        } catch (Exception $e) {
            $this["logger"]->error("Error: {$e->getMessage()}");
            return $response->withJson([
                        'error' => 1,
                        'desc' => 'Error procesando petición ' . $e->getMessage()], 400);
            // Véase códigos de error https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP
        }
        $desc = $ok ? '' : 'Error en operción insercion base de datos';
       // $this["logger"]->error("Error: {$e->getMessage()}");
        return $response->withJson([
                    'error' => !$ok,
                    'desc' => $desc,
                    'datos' => $datos_post]);
    } else {
        return $response->withJson([
                    'error' => 1,
                    'desc' => 'Formato campos incorrecto {cod, nombre}',
                    'datos' => $datos_post], 400);
        // Véase códigos de error https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP
    }
});

/**
 * PUT provincia/id
 * Actualiza los datos de la provincia almancedos en la posición id
 * Si ya existe se actualizan sus datos
 * 
 * Para que funcione correctamente en PostMan debemos seleccionar
 * el envío de datos en formato x-www-form-urlencoded
 */
$app->put('/objetivo/{id}', function (Request $request, Response $response, array $args) use($db_prov) {
    $id = $args['id'];
    
    $this["logger"]->debug('PUT /objetivo/' . $id);
    $this["logger"]->debug('PUT-BODY=' . $request->getBody()->getContents());


    $datos_put = $request->getParsedBody();
    $this["logger"]->debug('PUT-DATOS ' . print_r($datos_put, true));

    if (objetivo::isValidFromArray($datos_put)) {
        // Registro de por donde vamos pasando por si hay errores. Util para depurar
        $this["logger"]->debug('PUT 1'); 
        $objetivo = objetivo::LoadFromArray($datos_put);
        $this["logger"]->debug('PUT 2');
        try {
            $ok = $db_prov->update($id,$objetivo);
            $this["logger"]->debug('PUT 3');
        } catch (Exception $e) {
            $this["logger"]->debug('PUT 4');
            $this["logger"]->error("Error: {$e->getMessage()}");
            return $response->withJson([
                        'error' => 1,
                        'desc' => 'Error procesando petición ' . $e->getMessage()], 400);
            // Véase códigos de error https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP
        }
        $this["logger"]->debug('PUT 5');
        $desc = $ok ? '' : 'Error en operción actualización base de datos';
        return $response->withJson([
                    'error' => !$ok,
                    'desc' => $desc,
                    'datos' => $datos_put]);
    } else {
        $this["logger"]->debug('PUT 6');
        return $response->withJson([
                    'error' => 1,
                    'desc' => 'Formato campos incorrecto {cod, nombre} ' . print_r($datos_put, true),
                    'datos' => $datos_put], 400);
        // Véase códigos de error https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP
    }
});

/**
 * DELETE provincia/id
 * Deuelve información de una provincia referenciada por el indice id
 */
$app->delete('/objetivo/{id}', function (Request $request, Response $response, array $args) use($db_prov) {
    $id = $args['id'];
    $this["logger"]->debug('DELETE /objetivo/' . $id);

    try {
        $ok = $db_prov->remove($id);
    } catch (Exception $e) {
        $this["logger"]->error("Error: {$e->getMessage()}");
        return $response->withJson([
                    'error' => 1,
                    'desc' => 'Error procesando petición ' . $e->getMessage()], 400);
        // Véase códigos de error https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP
    }
    $desc = $ok ? '' : 'No existe el elemento';
    return $response->withJson([
                'error' => !$ok,
                'desc' => $desc], 404);
});


//////////////////////////////////////////////////////////////////////////////
//  Arrancamos la aplicación
//////////////////////////////////////////////////////////////////////////////

$app->run();
