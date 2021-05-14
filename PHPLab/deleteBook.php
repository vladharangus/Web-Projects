<?php

$con = mysqli_connect("localhost", "vlad", "1234", "library");
if (!$con) {
  die("Could not connect: " . mysqli_error());
}

$id = $_POST["id"];
$result = mysqli_query($con, "DELETE FROM books WHERE BookID = '" . $id . "'");
$result = mysqli_query($con, "DELETE FROM rentals WHERE bookID = '" . $id . "'");
mysqli_close($con);
header("Location: securePage.php");

?>
