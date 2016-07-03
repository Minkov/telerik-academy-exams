/* globals console require*/

"use strict";

let task1Solve = require("./task1");
let task2Solve = require("./task2");
let task3Solve = require("./task3");

let task1Tests = [
    [
        "5 1",
        "9 0 2 4 1"
    ],
    [
        "10 3",
        "1 9 1 9 1 9 1 9 1 9"
    ],
    [
        "10 10",
        "0 1 2 3 4 5 6 7 8 9"
    ]
];

let task2Tests = [
    "3",
    "4",
    "--R-",
    "B--B",
    "Q--Q",
    "12",
    "d1 b3",
    "a1 a3",
    "c3 b2",
    "a1 c1",
    "a1 b2",
    "a1 c3",
    "a2 b3",
    "d2 c1",
    "b1 b2",
    "c3 b1",
    "a2 a3",
    "d1 d3"
];

let task3Test = [
    "#the-big-b{",
    "   color: yellow;",
    "   size: big;",
    "}",
    ".muppet{",
    "   powers: all;",
    "  skin: fluffy;",
    "}",
    ".water-spirit{",
    "   powers: water;",
    "      alignment : not-good;",
    "}",
    "all{",
    "    meant-for: nerdy-children;",
    "}",
    ".muppet {",
    "   powers: everything;",
    "}",
    "all .muppet {",
    "     alignment:good",
    "}",
    ".muppet+   .water-spirit{",
    "    power: everything-a-muppet-can-do-and-water;",
    "}",
]

// task1Tests.forEach(test => task1Solve(test));

// task2Solve(task2Tests);
task3Solve(task3Test);