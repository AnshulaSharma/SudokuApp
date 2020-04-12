# SudokuApp

# Introduction
Sudoku Web App which generates a 6x6 puzzle and provides solution for it.

# Architecture
.Net Core WebAPI Project
 MVC used to only refer a startup View to consume the web Api

# How to run
	Requirment: Visual Studio as it runs on IIS, Browser
	Download/Clone the application and run the solution.
	The application should open in the browser https://localhost:44378/Sudoku and points to Startup View.

# How to access Web API
	#1 REST call to get puzzle
        {id} can be between 0-9 which will return different puzzle of size 6x6.
		
        curl -X GET \
        https://localhost:44378/Sudoku/puzzle/{id}\
        -H 'cache-control: no-cache' \
        -H 'content-type: application/json' \
        -H 'postman-token: 4994e855-61f0-ee1d-a767-0d1f02b1b35e'

    #2 REST call to get solution for puzzle
        body should be 2d array strictly of size 6x6.

        curl -X POST \
        https://localhost:44378/Sudoku/solution \
        -H 'cache-control: no-cache' \
        -H 'content-type: application/json' \
        -H 'postman-token: e7eed52b-34be-1f6b-d88a-7fa6a3dacfb9' \
        -d '{
                "arrSudoku":  [ [ 3, 6, 0, 0, 0, 5 ], [ 0, 0, 0, 2, 0, 3 ], [ 2, 3, 0, 4, 5, 1 ], [ 5, 0, 0, 3, 2, 0 ], [ 0, 0, 3, 5, 0, 4 ], [ 0, 0, 1, 0, 3, 2 ] ]
	        }'
# Command to run unit test coverage
	Open Developer Command Prompt
	Change directory to the test solution ~\SudokuApp.Tests\
	Run command dotnet test /p:CollectCoverage=true


