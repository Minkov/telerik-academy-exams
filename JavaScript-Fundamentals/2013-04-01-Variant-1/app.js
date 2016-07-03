function solve(args) {
    var numbers = args.slice(1).map(Number);
    var count = 0;

    for (let i = 1; i < numbers.length; i += 1) {
        if (numbers[i] < numbers[i - 1]) {
            count += 1;
        }
    }
    console.log(count);
}

solve(["9", "1", "8", "8", "7", "6", "5", "7", "7", "6"]);
