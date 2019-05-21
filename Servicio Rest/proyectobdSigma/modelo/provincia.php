<?php

/**
 * Clase en la que almacenaremos los datos de una provincia
 */
class Objetivos {

    public $objetivos;
    public $fecha;
    public $registro_id;

    public function __construct($objetivos='', $fecha='', $registro_id='') {
        $this->objetivos = $objetivos;
        $this->fecha = $fecha;
        $this->registro_id = $registro_id;
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
            if (isset($item['objetivos'])) {
                $peli->objetivos = $item['objetivos'];
            }
            if (isset($item['fecha'])) {
                $peli->fecha = $item['fecha'];
            }
            if (isset($item['registro_id'])) {
                $peli->registro_id = $item['registro_id'];
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
                isset($item['objetivos']) && // Tiene que tener cod
                isset($item['fecha']) &&
                isset($item['registro_id']) &&                            // Tiene que tener objetivos
                $item['objetivos'] != '' && // cod debe tener valor
                $item['fecha'] != ''&&
                $item['registro_id']!='';// objetivos debe tener valor       
    }

}
