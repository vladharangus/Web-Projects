<?php

  $con = mysqli_connect("localhost", "vlad", "1234", "library");
  if (!$con) {
    die("Could not connect: " . mysqli_error());
  }
  $result = mysqli_query($con, "SELECT * FROM books");
echo "<table border='1'><tr><th>ID</th><th>Author</th><th>Title</th><th>Pages</th><th>Genre</th></tr>";
$index = 0;
while($row = mysqli_fetch_array($result)){
  echo "<tr>";
  echo "<td>" . $row['BookID'] . "</td>";
  echo "<td>" . $row['Author'] . "</td>";
  echo "<td>" . $row['Title'] . "</td>";
  echo "<td>" . $row['Pages'] . "</td>";
  echo "<td>" . $row['Genre'] . "</td>";
  echo "</tr>";
  $index += 1;
}
echo "</table>";
mysqli_close($con);

?>
