# MovieApp
Tests around adding movies to an app

Tests are contained in MovieAppTests folder.
Tests focus only on the Create view, which is a page which allows the user to add a movie.

It is assumed that: </br>
Login page has been developed</br>
List view exists for set of movies</br>

Fields have these data requirements:</br>
Title - string, max 200 chars</br>
Release date - date, must be >= 1/10/2015</br>
Rating - integer, 1-5</br>

Button should only be enabled when all fields have valid data
