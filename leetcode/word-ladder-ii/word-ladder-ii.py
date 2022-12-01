class Solution:
    def findLadders(self, begin_word: str, end_word: str, word_list: list[str]) -> list[list[str]]:
        if end_word not in word_list: return []
        if begin_word not in word_list: word_list.append(begin_word)

        tree = self.build_tree(word_list)

        return self.get_shortest_path(begin_word, end_word, tree)

    def build_tree(self, word_list: list[str]) -> dict:
        m = {}

        for current in word_list:
            m[current] = []

            for w in word_list:
                if w == current:
                    continue

                if self.is_one_away(w, current):
                    m[current].append(w)

        return m

    def is_one_away(self, word_one: str, word_two: str) -> bool:
        diff = 0

        for i, _ in enumerate(word_one):
            if word_one[i] != word_two[i]:
                diff += 1

        return diff == 1

    def get_shortest_path(self, start_word: str, end_word: str, tree: dict[str, list[str]]) -> list[list[str]]:
        has_traversed = [start_word]

        return self.old_gp(start_word, end_word, tree, has_traversed, []);

    def old_gp(self, start_word: str, end_word: str, tree: dict[str, list[str]], has_traversed: list[str], current_path: list[str]) -> list[list[str]]:
        paths = []
        next_words = tree[start_word]

        if len(next_words) == 0:
            return paths

        # paths.append(start_word)

        for w in next_words:
            if w in has_traversed: continue

            has_traversed.append(w)

            if w == end_word:
                paths.append(w)
                return paths

            child_path = self.old_gp(w, end_word, tree, has_traversed, current_path)

            if end_word in child_path:
                paths = paths

        return paths

ladder = Solution().findLadders("aa", "xx", ["aa", "ax", "xx"])

print(ladder)

# {'abc': ['abd', 'abf'], 'abd': ['abc', 'acd', 'abf'], 'acd': ['abd'], 'axy': [], 'abf': ['abc', 'abd']}
