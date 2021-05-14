<?php
  session_start();
  $user = $_POST['user'];
  $password = $_POST['password'];
  $con = mysqli_connect("localhost", "vlad", "1234", "library");
  $id = mysqli_query($con, "SELECT userID FROM users WHERE user = '" . $user . "' AND password = '" . $password . "'");
  $row = mysqli_fetch_array($id);
  if ($row[userID]) {
    $_SESSION['validuser'] = $row[userID];;
    $_SESSION['user'] = $_POST['user'];
    header("Location: securePage.php");
  }
  else {
    header("Location: distroySession.php");
  }
?>
