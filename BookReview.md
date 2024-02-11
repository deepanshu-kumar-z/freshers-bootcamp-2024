# Chapter 8: Breaking Down Giant Expressions

**Key Idea**:  Break down your giant expressions into more digestible pieces.


## **1. Explaining Variables**

- **Creating new variable**: Introduce an extra variable that captures a smaller subexpression.
  - *Example*:
    ```cpp
    if line.split(':')[0].strip() == "root":
 	...
    ```
    *This code can be replaced by*:
    ```cpp
    username = line.split(':')[0].strip()
    if username == "root":
 	...
    ```

- **Summary Variables**: Replace a larger chunk of code with a smaller name that can be managed and thought about more easily.
  - *Example*:
    ```cpp
    if (request.user.id == document.owner_id) {
 	// user can edit this document...
    }
    ...
    if (request.user.id != document.owner_id) {
 	// document is read-only...
    }
    ```
    *This code can be replaced by*:
    ```cpp
    final boolean user_owns_document = (request.user.id == document.owner_id);
    if (user_owns_document) {
   	// user can edit this document...
    }
    ...
    if (!user_owns_document) {
	 // document is read-only...
    }
 	...
    ```


## **2. Using De Morgan’s Laws**

- **Laws**:  They are two ways to rewrite a boolean expression into an equivalent one:
	1) not (a or b or c) ⇔ (not a) and (not b) and (not c)
	2) not (a and b and c) ⇔ (not a) or (not b) or (not c)

- **Readability**: Use above laws to make a boolean expression more readable.
  - *Example*:
    ```cpp
    if (!(file_exists && !is_protected)) Error("Sorry, could not read file.");
    ```
    *This code can be replaced by*:
    ```cpp
    if (!file_exists || is_protected) Error("Sorry, could not read file.");
    ```


## **3. Abusing Short-Circuit Logic**

- **Short-circuit evaluation**: Works with Boolean operators. For example, the statement if (a || b) won’t evaluate b if a is true. This behavior is very handy but can sometimes be abused to accomplish complex logic.
  - *Example*:
    ```cpp
    assert((!(bucket = FindBucket(key))) || !bucket->IsOccupied());
    ```
    This code means, “Get the bucket for this key. If the bucket is not null, then make sure it isn’t occupied.”
    Even though it is a single line of code, it works as a mental speed bump for anyone reading through the code.
    *This code can be replaced by*:
    ```cpp
    bucket = FindBucket(key);
    if (bucket != NULL) assert(!bucket->IsOccupied());
    ```
  - *Key Idea*:
    Beware of “clever” nuggets of code—they’re often confusing when others read the code later.
  - It does not mean we should avoid making use of short-circuit behavior, we just have to use it cleanly.


## **4. Example: Wrestling with Complicated Logic**

   - Implementing the `OverlapsWith()` method for a `Range` class.
   - Initial attempt:
     ```cpp
     bool Range::OverlapsWith(Range other) {
         return (begin >= other.begin && begin <= other.end) ||
                (end >= other.begin && end <= other.end);
     }
     ```
   - Despite being concise, this code is complex and prone to bugs.
   - Issues arise due to comparing `begin` and `end` values.
   - Multiple fixes are needed to address all edge cases, leading to convoluted code.


## **5. Finding a More Elegant Approach**

   - Considering a different approach to simplify the logic.
   - Instead of directly checking overlap, consider checking for non-overlap.
   - Simplified approach:
     ```cpp
     bool Range::OverlapsWith(Range other) {
         if (other.end <= begin) return false; // They end before we begin
         if (other.begin >= end) return false; // They begin after we end
         return true; // Only possibility left: they overlap
     }
     ```
   - Each line of code handles only one comparison, making it easier to understand and maintain.


## **6. Breaking Down Giant Statements**

   - Techniques for breaking down larger statements.
   - Example of JavaScript code with multiple expressions.
   - Extracting common expressions as summary variables.
   - Improves readability and maintainability of the code.


## **7. Another Creative Way to Simplify Expressions**

   - Using macros in C++ to simplify repetitive code.
   - Example of `AddStats()` function where multiple similar lines are condensed using macros.
   - While macros are not always recommended, they can be beneficial for clarity in certain cases.


## **Final Thoughts**

- **Improving code**: This chapter discusses breaking down giant expressions into smaller parts using techniques like explaining variables, De Morgan's laws, and improving code. These techniques help break down complex logical conditions into smaller statements, documenting the code with a concise name and identifying main concepts. The chapter also emphasizes the importance of breaking down larger blocks of code, highlighting the need for aggressive breaking down of complex logic.
