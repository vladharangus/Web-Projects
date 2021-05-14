<?php

$con = mysqli_connect("localhost", "vlad", "1234", "library");
if (!$con) {
  die("Could not connect: " . mysqli_error());
}

$a = $_POST["author"];
$t = $_POST["title"];
$p = $_POST["pages"];
$g = $_POST["genre"];
$result = mysqli_query($con, "INSERT INTO books VALUES( NULL, '" . $a . "', '" . $t . "', '" . $p . "', '" . $g ."')");
mysqli_close($con);
header("Location: securePage.php");

?>
