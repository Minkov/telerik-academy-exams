let task1Solve = require("./task1");
let task2Solve = require("./task2");
let task3Solve = require("./task3");

let task1Tests = [
    ["5 1 7 4 8"],
    ["5 1 7 6 3 6 4 2 3 8"],
    ["10 1 2 3 4 5 4 3 2 1 10"],
    ["6 4 2 3 6 5 7 6 3 4"]
];
// task1Tests.forEach(test => task1Solve(test));


let task2Tests = [
"3",
"4",
"--K-",
"K--K",
"Q--Q",
"12",
"d1 b3",
"a1 a3",
"c3 b2",
"a1 c1",
"a1 b2",
"a1 c3",
"a2 c1",
"d2 b1",
"b1 b2",
"c3 a3",
"a2 a3",
"d1 d3"
];

// task2Solve(task2Tests);



let task3Test = [
    "#the-big-b              #k         {",
    "     color: big-yellow;",
    "        .little-bs {",
    "           color: little-yellow;",
    "              $.male{",
    "                  color: middle-yellow;",
    "                 }",
    "         }",
    "}",
    ".muppet{",
    "   skin:fluffy;",
    "     $.water-spirit                    {",
    "      powers : water;",
    "     }",
    "    $>thread{",
    "      color: depends;",
    "   }",
    "   powers : all-muppet-powers;",
    "}"
];

task3Solve(task3Test);