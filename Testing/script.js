document.addEventListener('DOMContentLoaded', function () {
   'use strict';
   document.querySelector('#login-click').addEventListener('click', function () {
      var login = document.getElementById('id04');

      // When the user clicks anywhere outside of the login, close it
      window.onclick = function(event) {
         if (event.target == login) {
            login.style.display = "none";
         }
      }
   }, false);
}, false);

