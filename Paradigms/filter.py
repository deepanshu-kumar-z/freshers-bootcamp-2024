def filter(input_str, criteria_function):
    answer_list = []
    for string in input_str:
        if criteria_function(string):
            answer_list.append(string)
    return answer_list
    
def check_string_starting_with(list_of_characters_to_match):
    predicate = lambda string : string[0] == char
    return predicate
    
def check_string_ending_with(list_of_characters_to_match):
    predicate = lambda string : string[-1] == char
    return predicate
    
def printToTerminal(output_str_list):
    for string in output_str_list:
        print(string)

array_of_strings = ['Abhishek','abhinav','Deepanshu','Vishal','Manisha','Dadlani']

print("Names starting with specified characters :")
for char in ['a','A','d','V','p']:
    result = filter(array_of_strings, check_string_starting_with(char))
    printToTerminal(result)
    
print("")

print("Names ending with specified characters :")
for char in ['a','A','d','V','p']:
    result = filter(array_of_strings, check_string_ending_with(char))
    printToTerminal(result)
