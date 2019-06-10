<?php
class Database {
 
    // specify your own database credentials
    private $host = "localhost";
    private $db_name = "sigmapyme";
    private $username = "root";
    private $password = "";
    public $conn=NULL;
    
    // Contenedor Instancia de la clase
    private static $instance = NULL;    
 
    // METODOS PATRON SINGLETON
    
    /**
     * Constructor privado para implementar el patrón de diseño Singleton
     * El patrón singleton nos garantiza que solo habrá un objeto de esta clase
     * Solo pueden crear objetos los métodos de la clase
     * 
     * Patrón Singleton: https://es.wikipedia.org/wiki/Singleton
     */
    private function __construct() {
        $this->createConnection();
    }
    
    // Clone no permitido
    private function __clone() { }

    // Método singleton 
    public static function getInstance()
    {
        if (is_null(self::$instance)) {
            // Es la primera vez
            self::$instance = new Database();
        }

        return self::$instance;
    }    
    
    
    // METODOS DE DATABASE
    
    // get the database connection
    private function createConnection(){
 
        $this->conn = null;
 
        try{
            $this->conn = new PDO("mysql:host=" . $this->host . ";dbname=" . $this->db_name, $this->username, $this->password);
            $this->conn->exec("set names utf8");
        }catch(PDOException $exception){
            echo "Connection error: " . $exception->getMessage();
        }

    }
    
    public function getConnection() {
        return $this->conn;
    }
    
    /**
     * Ejecuta consulta de selección
     * @param type $sql
     * @return type
     */
    public function query($sql) {
        return $this->conn->query($sql);
    }
    
    /**
     * Ejecuta consulta de actualización
     * 
     * @param type $sql
     * @return type
     */
    public function exec($sql) {
        return $this->conn->exec($sql);
    }
}


