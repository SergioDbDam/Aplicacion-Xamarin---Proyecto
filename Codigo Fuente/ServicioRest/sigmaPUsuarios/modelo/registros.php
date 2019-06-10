<?php

/**
 * Clase en la que almacenaremos los datos de una provincia
 */
class Objetivos {

    public $nombre;
    public $contrasena;
    public $rol;

    public function __construct($nombre='', $contrasena='', $rol='') {
        $this->nombre = $nombre;
        $this->contrasena = $contrasena;
        $this->rol = $rol;
    }

    /**
     * Crea un nuevo objeto a partir de los datos contenidos en un array que
     * contiene los atributos requeridos
     * 
     * @param type $item
     * @return \Objetivos
     */
    static public function LoadFromArray(& $item) {
        $peli = new Objetivos();
        if (is_array($item)) {
            if (isset($item['nombre'])) {
                $peli->nombre = $item['nombre'];
            }
            if (isset($item['contrasena'])) {
                $peli->contrasena = $item['contrasena'];
            }
            if (isset($item['rol'])) {
                $peli->rol = $item['rol'];
            }
        }
        return $peli;
    }

    /**
     * Comprueba si un array tiene los campos correctos para rellenar 
     * el array
     * @param type $item
     * @return type
     */
    static public function isValidFromArray(& $item) {
        return
                is_array($item) &&
                count($item) == 3 && // Solo 2 campos
                isset($item['nombre']) && // Tiene que tener cod
                isset($item['contrasena']) &&
                isset($item['rol']) &&                            // Tiene que tener objetivos
                $item['nombre'] != '' && // cod debe tener valor
                $item['contrasena'] != ''&&
                $item['rol']!='';// objetivos debe tener valor       
    }

}
