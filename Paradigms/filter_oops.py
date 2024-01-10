class StringFilter:
    def __init__(self, input_str):
        self.input_str = input_str

    def filter(self, criteria_function):
        return [string for string in self.input_str if criteria_function(string)]

def check_string_starting_with(char):
    predicate = lambda string: string[0] == char
    return predicate

def check_string_ending_with(char):
    predicate = lambda string: string[-1] == char
    return predicate

def print_to_terminal(output_str_list):
    for string in output_str_list:
        print(string)


if __name__ == "__main__":
    array_of_strings = ['Abhishek', 'abhinav', 'Deepanshu', 'Vishal', 'Manisha', 'Dadlani']

    string_filter = StringFilter(array_of_strings)

    print("Names starting with specified characters:")
    for char in ['a', 'A', 'd', 'V', 'p']:
        result = string_filter.filter(check_string_starting_with(char))
        print_to_terminal(result)

    print("")

    print("Names ending with specified characters:")
    for char in ['a', 'A', 'd', 'V', 'p']:
        result = string_filter.filter(check_string_ending_with(char))
        print_to_terminal(result)
