<?php
    session_start();
    include 'database.php';

    if(isset($_POST['option0']) || isset($_POST['option1'])){
        $option0 = $_POST['option0'];
        $option1 = $_POST['option1'];

        if($option0){
            $sql_in_0 = "INSERT INTO finaleoption (option_selected) VALUES (0)";
            $result_in_0 = $conn->query($sql_in_0);
		}else if($option1){
            $sql_in_1 = "INSERT INTO finaleoption (option_selected) VALUES (1)";
            $result_in_1 = $conn->query($sql_in_1);
		}
        header("location: ../ThankYouPage.html");
        exit();
	}
?>