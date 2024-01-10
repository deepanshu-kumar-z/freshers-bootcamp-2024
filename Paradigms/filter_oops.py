class StringFilter:
    def __init__(self, input_str):
        self.input_str = input_str

    def filter(self, criteria_function):
        return [string for string in self.input_str if criteria_function(string)]

class checkStringStart:
    def __init__(self, char):
        self.char = char
        
    def check_string_starting_with(self):
        predicate = lambda string: string[0] == self.char
        return predicate

class checkStringEnd:
    def __init__(self, char):
        self.char = char
        
    def check_string_ending_with(self):
        predicate = lambda string: string[-1] == self.char
        return predicate

class stringPrint:
    def __init__(self,output_str_list):
        self.output_str_list = output_str_list
    def print_to_terminal(self):
        for string in self.output_str_list:
            print(string)


if __name__ == "__main__":
    array_of_strings = ['Abhishek', 'abhinav', 'Deepanshu', 'Vishal', 'Manisha', 'Dadlani']

    string_filter = StringFilter(array_of_strings)

    print("Names starting with specified characters:")
    for char in ['a', 'A', 'd', 'V', 'p']:
        check_string = checkStringStart(char)
        result = string_filter.filter(check_string.check_string_starting_with())
        string_print = stringPrint(result)
        string_print.print_to_terminal()

    print("")

    print("Names ending with specified characters:")
    for char in ['a', 'A', 'd', 'V', 'p']:
        check_string = checkStringEnd(char)
        result = string_filter.filter(check_string.check_string_ending_with())
        string_print = stringPrint(result)
        string_print.print_to_terminal()
