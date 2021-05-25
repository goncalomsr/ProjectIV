<?php
    include 'database.php';

    $count_votes_0 = "SELECT * FROM finaleoption WHERE option_selected = 0";
        $result_0 = $conn->query($count_votes_0);

    $row_0 = $result_0->num_rows;

    $count_votes_1 = "SELECT * FROM finaleoption WHERE option_selected = 1";
        $result_1 = $conn->query($count_votes_1);

    $row_1 = $result_1->num_rows;

    if ($row_0 > $row_1)
    {
        echo "0";
	}
    
    if ($row_0 < $row_1){
        echo "1";
	}
    
    if ($row_0 == $row_1){
        echo rand(0, 1);
	}

?>