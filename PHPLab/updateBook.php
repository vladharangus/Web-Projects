<?php

$con = mysqli_connect("localhost", "vlad", "1234", "library");
if (!$con) {
  die("Could not connect: " . mysqli_error());
}
$id = $_POST["id"];
$a = $_POST["author"];
$t = $_POST["title"];
$p = $_POST["pages"];
$g = $_POST["genre"];
$result = mysqli_query($con, "UPDATE books SET Author = '" . $a . "', Title = '" . $t . "', Pages = '" . $p . "', Genre = '" . $g . "' WHERE BookID = '" . $id ."'");
mysqli_close($con);
header("Location: securePage.php");

?>
