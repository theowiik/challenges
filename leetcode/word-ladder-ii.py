class Solution:
    def findLadders(self, begin_word: str, end_word: str, word_list: list[str]) -> list[list[str]]:
        if end_word not in word_list: return []
        if begin_word not in word_list: word_list.append(begin_word)

        close_map = self.build_map(word_list)
        all_paths = self.get_all_paths(begin_word, end_word, close_map)

        return self.shortest_arr(all_paths)

    def shortest_arr(self, all_paths: list[list[any]]) -> list[str]:
        print(all_paths)
        return all_paths.sort(key=self.stupid_change)[0]

    def stupid_change(self, item1: list[any], item2: list[any]) -> int:
        print('kpfdokpofkdsp')
        if len(item1) < len(item2):
            return -1
        elif len(item1) > len(item2):
            return 1
        else:
            return 0

    def build_map(self, word_list: list[str]) -> dict:
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

    def get_all_paths(self, start_word: str, end_word: str, close_map: dict[str, list[str]]) -> list[list[str]]:
        has_traversed = [start_word]

        return self.gp(start_word, end_word, close_map, has_traversed);

    def gp(self, start_word: str, end_word: str, close_map: dict[str, list[str]], has_traversed: list[str]) -> list[list[str]]:
        paths = []
        next_words = close_map[start_word]

        if len(next_words) == 0:
            return paths

        for w in next_words:
            if w in has_traversed: continue
            if w == end_word: return paths

            has_traversed.append(w)
            paths = paths + self.gp(w, end_word, close_map, has_traversed)

        return paths
        

sol = Solution()
ladder = sol.findLadders("abc", "abf", ["abc", "abd", "acd", "axy", "abf"])
