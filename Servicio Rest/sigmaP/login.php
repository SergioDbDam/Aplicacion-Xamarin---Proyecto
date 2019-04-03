<?php   
    $conn = new mysqli('localhost', 'root', '');  
    mysqli_select_db($conn, 'sigmapyme');  
    if (isset($_GET['username']) && $_GET['username'] != '' &&isset($_GET['password']) && $_GET['password'] != '')   
    {  
        $name = $_GET['username'];  
        $password = $_GET['password'];   
        $registro="registro";
        $getData = "SELECT id,nombre,contrasena,rol FROM $registro WHERE nombre='$name' and contrasena='$password' ";  

        
        $result = mysqli_query($conn,$getData);  
        if($result === false) {
            echo "error while executing mysql: " . mysqli_error($conn);
           } 
        while( $r = mysqli_fetch_row($result))  
        {  
            $userId=$r[0]; 
            $userRol=$r[3]; 
        }  
  
        if ($result->num_rows> 0 ){  
  
            $resp["status"] = "1";  
            $resp["userid"] = $userId; 
            $resp["rol"]= $userRol; 
            $resp["message"] = "Login successfully";
           
        }  
      else
        {

           
        }       

       }
  
   
    
  
    header('content-type: application/json');  
  
    $response["respuesta"]=$resp;  
    $out=json_encode($response);  
    echo($out);
    @mysqli_close($conn);  
  
?>  