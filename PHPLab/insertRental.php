<?php

$con = mysqli_connect("localhost", "vlad", "1234", "library");
if (!$con) {
  die("Could not connect: " . mysqli_error());
}

$b = $_POST["book"];
$d = $_POST["date"];

$result = mysqli_query($con, "INSERT INTO rentals VALUES( NULL, '" . $b . "', '" . $d ."')");
mysqli_close($con);
header("Location: securePage.php");

?>
