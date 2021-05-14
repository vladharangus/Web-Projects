<!doctype html>
<html class="no-js" lang="">

<head>
  <title>Library</title>
  <script src = "jquery-3.5.0.min.js"></script>
  <script>
    $(document).ready(function () {
      $("#button").click(function () {
        $.post("getBooks.php",function (data, status) {
            $("#maindiv").html(data);
        })

      })

    })
    $(document).ready(function () {
      $("#buttonRentals").click(function () {
        $.post("getRentals.php",function (data, status) {
          $("#maindiv").html(data);
        })

      })

    })
    $(document).ready(function () {
      $("#buttonFilter").click(function () {
        $.post("filterBook.php", {genre: document.getElementById("genreinput").value},function (data, status) {
          $("#maindiv").html(data);
        })
        var div = document.getElementById('filterdiv');
        div.innerHTML += document.getElementById("genreinput").value  + " ";
      })

    })


  </script>
</head>
<body>
  <?php
  session_start();
  if (!isset($_SESSION['validuser'])) {
    header('Location: login.html');
  } else {
    echo "<form action='distroySession.php' method='post'>";
    echo " 	 <input type='submit' value='Logout' name='logout' />";
    echo "</form>";
  }
  ?>
  <div id = "maindiv"></div>

  <br />
  <form action='insertBook.php' method='post'>
    Author: <input type="text" name = "author" />
    Title: <input type="text" name = "title" />
    Pages: <input type="text" name = "pages" />
    Genre: <input type="text" name = "genre" />
    <input type='submit' value='Insert Book' name='insertB' />
  </form>
  <br />
  <br />
  <form action='insertRental.php' method='post'>
    Book ID: <input type="text" name = "book" />
    Booking Date: <input type="text" name = "date" />
    <input type='submit' value='Insert Rental' name='insertR' />
  </form>
  <br />
  <br />

  <form action='deleteBook.php' method='post'>
    ID: <input type="text" name = "id" />
    <input type='submit' value='Delete' name='delete' />
  </form>
<br />
<br />
  <div id = "filterdiv">Previous filters: </div>
  Genre: <input id = "genreinput" type="text" name = "genre" />
  <button id = "buttonFilter" type="button">Filter</button>
  <br />
  <br />

  <form action='updateBook.php' method='post'>
    ID: <input type="text" name = "id" />
    Author: <input type="text" name = "author" />
    Title: <input type="text" name = "title" />
    Pages: <input type="text" name = "pages" />
    Genre: <input type="text" name = "genre" />
    <input type='submit' value='Update Book' name='update' />
  </form>
  <br />
  <br />
  <button id = "button" type="button">Get Books</button>
  <button id = "buttonRentals" type="button">Get Rentals</button>
</body>

</html>
