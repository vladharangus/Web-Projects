<?php

$con = mysqli_connect("localhost", "vlad", "1234", "library");
if (!$con) {
  die("Could not connect: " . mysqli_error());
}

$genre = $_POST["genre"];
$result = mysqli_query($con, "SELECT * FROM books WHERE Genre = '" . $genre . "'");
echo "<table border='1'><tr><th>ID</th><th>Author</th><th>Title</th><th>Pages</th><th>Genre</th></tr>";
while($row = mysqli_fetch_array($result)){
  echo "<tr>";
  echo "<td>" . $row['BookID'] . "</td>";
  echo "<td>" . $row['Author'] . "</td>";
  echo "<td>" . $row['Title'] . "</td>";
  echo "<td>" . $row['Pages'] . "</td>";
  echo "<td>" . $row['Genre'] . "</td>";
  echo "</tr>";
}
echo "</table>";
mysqli_close($con);

?>
