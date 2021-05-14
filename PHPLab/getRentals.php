<?php

$con = mysqli_connect("localhost", "vlad", "1234", "library");
if (!$con) {
  die("Could not connect: " . mysqli_error());
}
$result = mysqli_query($con, "SELECT * FROM rentals");
echo "<table border='1'><tr><th>ID</th><th>Book ID</th><th>Booking Date</th></tr>";
while($row = mysqli_fetch_array($result)){
  echo "<tr>";
  echo "<td>" . $row['rentalID'] . "</td>";
  echo "<td>" . $row['bookID'] . "</td>";
  echo "<td>" . $row['bookingDate'] . "</td>";
  echo "</tr>";
}
echo "</table>";
mysqli_close($con);

?>
