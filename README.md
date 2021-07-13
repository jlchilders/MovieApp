# MovieApp
Tests around adding movies to an app

Tests are contained in MovieAppTests folder.
Tests focus only on the Create view, which is a page which allows the user to add a movie.

It is assumed that:
Login page has been developed
List view exists for set of movies

Fields have these data requirements:
Title - string, max 200 chars
Release date - date, must be >= 1/10/2015
Rating - integer, 1-5

Button should only be enabled when all fields have valid data
