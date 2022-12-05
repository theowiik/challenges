import pprint

pp = pprint.PrettyPrinter(indent=2)


def to_instruction(row):
    split = row.split(" ")
    return (int(split[1]), int(split[3]) - 1, int(split[5]) - 1)


moves = []
stacks = []

f = open('data', 'r')
for l in f:
    if l.startswith("move"):
        moves.append(to_instruction(l))
        continue

    if "[" in l:

        i = 0
        size = len(l)
        while i < size:
            if "[" in l[i:i+3]:
                while len(stacks) <= i / 4: stacks.append([])
                stacks[int(i/4)].insert(0, l[i:i+3][1])
            i += 4

f.close()

pp.pprint(stacks)

part_one = False
if part_one:
    for move in moves:
        for _ in range(move[0]):
            popped = stacks[move[1]].pop()
            stacks[move[2]].append(popped)
else:
    for move in moves:
        stack = stacks[move[1]]

        m = stack[len(stack)-move[0]:len(stack)]

        for i in m:
            stacks[move[1]].pop()
            stacks[move[2]].append(i)

final = ""
for stack in stacks:
    final += stack.pop()

print('\nFinal: ' + final)
