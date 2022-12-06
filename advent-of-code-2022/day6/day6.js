const fs = require('fs');
const line = fs.readFileSync('data').toString();

// "a bacd xxx" // 5
// "0 1234 56789" // 1 + 4 = 5

let i = 0;

for (char in line) {
  const subPart = line.substring(i, i + 4).split('');

  const hasDupe = subPart.some(
    (c) => subPart.indexOf(c) !== subPart.lastIndexOf(c)
  );

  if (!hasDupe) {
    console.log(`Part 1: ${i + 4}`);
    break;
  }

  i++;
}
