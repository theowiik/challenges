// Purposefully slow version of day6.js. Why was part 2 so similar?
// Is it because an inefficient algorithm was assumed to be used?

const console = require('console');
const fs = require('fs');
const line = fs.readFileSync('data').toString();

const slow = (data, length) => {
  let res = -1;

  for (let i = 0; i < data.length; i++) {
    let subPart = ""

    if (i < length) continue

    for (let x_i = 0; x_i < length; x_i++) {
      subPart += data[x_i - i]
    }

    console.log(subPart)

    if (!hasDuplicate(subPart) && res === -1) res = i + length;
  }

  return res;
};

/**
 * N^2
 */
hasDuplicate = (str) => {
  let has = false;

  for (let a_i = 0; a_i < str.length; a_i++) {
    for (let b_i = 0; b_i < str.length; b_i++) {
      if (a_i === b_i) continue;

      if (str[a_i] === str[b_i]) has = true;
    }
  }

  return has;
};

console.log(`Part 1: ${slow(line, 4)}`);
console.log(`Part 2: ${slow(line, 14)}`);
