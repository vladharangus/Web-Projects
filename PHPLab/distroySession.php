<?php
  session_start();
  if(isset($_SESSION['validuser']))
    unset($_SESSION['validuser']);
  session_destroy();
  header("Location: login.html");
?>
