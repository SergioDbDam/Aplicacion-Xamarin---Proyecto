<?php

include __DIR__ . '/db.php';
include __DIR__ . '/registros.php';

/**
 * Clase auxiliar que facilitara las operaciones con la BBDD
 */
class registros_DBHelper {

    private $db;
    private $logger = NULL;

    /**
     * Constructor
     */
    public function __construct() {
        $this->db = Database::getInstance();
    }

    /**
     * Devuelve todos los elementos almancenados
     */
    public function getAll() {
        $sql = "select * from objetivos order by id";
        $this->logDebug("DB_Prov::getAll \n" . $sql);
        $rs = $this->db->query($sql);
        return $rs->fetchAll(PDO::FETCH_OBJ);
    }

    /**
     * Devuelve el elemento con indice id
     * @param type $cod
     * @return record | null 
     */
    public function get($id) {
        $sql = "select * from objetivos where registro_id=$id and cumplido='0'";
        $this->logDebug("DB_Prov::get \n" . $sql);
        $rs = $this->db->query($sql);
        return $rs->fetchAll(PDO::FETCH_OBJ);
    }

    /**
     * Devuelve el indice de un código en la lista
     * @param type $cod
     * @return record | null
     */
    public function getByname($nombre) {
        $sql = "select * from objetivos where objetivos='$nombre'";
        $this->logDebug("DB_Prov::getByCod \n" . $sql);
        $rs = $this->db->query($sql);
        return $rs->fetch(PDO::FETCH_OBJ);
    }

    /**
     * Nos indica si existe una provincia con indice id
     * @param int $idx
     * @return boolean
     */
    function exists($id) {
        $sql = "select * from objetivos where id=$id";
        $this->logDebug("DB_Prov::exists \n" . $sql);
        $rs = $this->db->query($sql);
        return $rs->fetch(PDO::FETCH_OBJ) != NULL;
    }

    /**
     * Añade una provincia a la tabla
     * 
     * @return item   Devuelve el elemento insertado
     */
    function add($objetivo) {
        $sql = "insert into objetivos (objetivos,fecha,cumplido,registro_id) "
                . "values ('{$objetivo->objetivos}','{$objetivo->fecha}','{$objetivo->cumplido}','{$objetivo->registro_id}')";
        $this->logDebug("DB_Prov::add \n" . $sql);

        $ok = $this->db->exec($sql);

        return $ok;
    }

    /**
     * Borra el elemento situado
     */
    function remove($id) {
        $sql = "delete from objetivos where id=$id";
        $this->logDebug("DB_Prov::remove \n" . $sql);
        $ok = $this->db->exec($sql);

        return $ok;
    }

    /**
     * Actualiza el elemento
     */
    function update($id, $objetivo) {
        $sql = "update objetivos set "
                . "objetivos='{$objetivo->objetivos}', "
                 . "fecha='{$objetivo->fecha}', "
                 . "cumplido='{$objetivo->cumplido}', "
                . "registro_id='{$objetivo->registro_id}' "
                . "where id=$id";
        $this->logDebug("DB_Prov::update \n" . $sql);

        $ok = $this->db->exec($sql);

        return $ok;
    }

    /// FUNCIONES PARA HACER LOG

    public function setLogger(\Monolog\Logger $log) {
        $this->logger = $log;
    }

    public function logDebug($msg) {
        if ($this->logger) {
            $this->logger->debug($msg);
        }
    }

}
