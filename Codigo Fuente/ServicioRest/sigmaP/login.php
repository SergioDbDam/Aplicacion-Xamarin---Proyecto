<?php   
    $conn = new mysqli('localhost', 'root', '');  
    mysqli_select_db($conn, 'sigmapyme');  
    if (isset($_GET['username']) && $_GET['username'] != '' &&isset($_GET['password']) && $_GET['password'] != '')   
    {  
        $name = $_GET['username'];  
        $password = sha1($_GET['password']);  
        $registro="registro";
        $getData = "SELECT id,nombre,rol FROM $registro WHERE nombre='$name' and contrasena='$password'";  

      
        $result = mysqli_query($conn,$getData);  
        if($result === false) {
            echo "error while executing mysql: " . mysqli_error($conn);
           } 
        while( $r = mysqli_fetch_row($result))  
        {  
            $userId=$r[0]; 
            $userName=$r[1];
            $userRol=$r[2]; 
        }  
  
        if ($result->num_rows> 0 ){  
            $resp["id"]= $userId;
            $resp["usuario"]=$userName;
            $resp["contrasena"]="Secreto";
            $resp["rol"]=$userRol;
           //$resp[$userRol]= $userRol; 
          // $resp["message"] = "Login successfully";
           
        }  
      else
        {
            $resp["id"]= 0;
            $resp["usuario"]="error";
            $resp["contrasena"]="error";
            $resp["rol"]="error";
           
        }       

       }
  
    header('content-type: application/json');  
   //$response["respuesta"]=$resp;  
    $out=json_encode($resp);
   // $out=json_encode($resp2)  
    echo($out);
    
   
    @mysqli_close($conn);  
  
?>  