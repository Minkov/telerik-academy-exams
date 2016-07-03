/* globals console */

function solve(args) {
    let rows = +args[0];

    let board = args.slice(2, rows + 2);

    let moves = args.slice(rows + 2 + 1)
        .map(parseMove);

    moves.forEach(move => {
        let piece = board[move.rowFrom][move.colFrom];
        if (isEmpty(piece)) {
            console.log("no");
            return;
        }

        if (isRook(piece) &&
            move.rowFrom !== move.rowTo &&
            move.colFrom !== move.colTo) {
            console.log("no");
            return;
        }

        if (isBishop(piece) &&
            (move.rowFrom === move.rowTo ||
                move.colFrom === move.colTo)) {
            console.log("no");
            return;
        }

        let rowUpdate = getValueUpdate(move.rowFrom, move.rowTo);
        let colUpdate = getValueUpdate(move.colFrom, move.colTo);

        let row = move.rowFrom + rowUpdate,
            col = move.colFrom + colUpdate;

        while (board[row] && board[row][col]) {
            if (!isEmpty(board[row][col])) {
                console.log("no");
                return;
            }
            else if (row === move.rowTo && col === move.colTo) {
                console.log("yes");
                return;
            }

            row += rowUpdate;
            col += colUpdate;
        }

        console.log("no");
    });

    function parseMove(moveStr) {
        //d1 b3
        //["d1", "b3"]
        let moveParts = moveStr.split(" ");

        let colFromStr = moveParts[0][0];
        let colFrom = colFromStr.charCodeAt(0) - "a".charCodeAt(0);

        let colToStr = moveParts[1][0];
        let colTo = colToStr.charCodeAt(0) - "a".charCodeAt(0);

        return {
            "rowFrom": rows - moveParts[0][1],
            "colFrom": colFrom,
            "rowTo": rows - moveParts[1][1],
            "colTo": colTo
        };
    }

    function isEmpty(piece) {
        return piece === "-";
    }

    function isRook(piece) {
        return piece === "R";
    }

    function isBishop(piece) {
        return piece === "B";
    }

    function getValueUpdate(from, to) {
        if (from === to) {
            return 0;
        }

        else if (from < to) {
            return +1;
        }

        return -1;
    }
}

module.exports = solve;