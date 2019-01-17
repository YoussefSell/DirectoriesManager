# DirectoriesManager
![Directories Manager](https://github.com/YoussefSell/DirectoriesManager/blob/master/demo%20app.PNG "Directories Manager")

this application is used to manage directories it give you three main functionalities, you can search inside a folder,
you can compare two folders and you can rename a list of folders. the app is built with .Net 4.7.2 using Winforms Project type, the app
is laverging the [DirectoryManager](https://github.com/YoussefSell/DirectoryManager) plugin to do all of it functionality

=> the search operation can be performed using two options, you can search with a text and app will give you all subdirectories 
that they contain the text or even a single character in there names, you can also search with regex but you need to have some 
knowledge on the topic of regex, for example you can put "\d" and the app will get you all subdirectories that they contain a one digit in 
there name etc.

=> the compare option give you the possibility to compare two directories, using the their names or date of creation etc, you can specify
what result you want, from "Matching" to give you the list of subdirectories that exist in both directory, or "Non-Matching" to get the
list of subdirectories that exist in the source folder (primary directory) but they don't exist in the "Folder To Compare" (Secondary Directory).

=> the Rename option give the possibility to rename a set of directories using a lot of options like generating random names 
for the folders, or by adding incremental numbers to beginning or the end, even you can use regex to remove or replace matched pattern,
just pay attention to regex options and test your regex pattern first.

=> you can also perform the copy and move operation on your results.and choose your output directory or destination directory where you want
your directories to be moved or copied
