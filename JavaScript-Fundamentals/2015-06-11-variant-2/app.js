let task1Solution = require("./task1");
let task2Solution = require("./task2");

let task1Tests = [
    ["5 1 7 4 8"],
    ["5 1 7 6 3 6 4 2 3 8"],
    ["10 1 2 3 4 5 4 3 2 1 10"]
];

let task2Tests = [
    ["3", "4", "--K-", "K--K", "Q--Q", "12", "d1 b3", "a1 a3", "c3 b2", "a1 c1", "a1 b2", "a1 c3", "a2 c1", "d2 b1", "b1 b2", "c3 a3", "a2 a3", "d1 d3"],
    ["5", "5", "Q---Q", "-----", "-K---", "--K--", "Q---Q", "10", "a1 a1", "a1 d4", "e1 b4", "a5 d2", "e5 b2", "b3 d4", "b3 c1", "b3 d1", "c2 a3", "c2 b"]
];

// task1Tests.forEach(test => task1Solution(test));
task2Tests.forEach(test => {
    task2Solution(test);
    console.log('----------------')
});