# WebContentExtractor

#Steps to follow
1. Download or clone the project "WebContentExtractor" from Repository .
2. Clean and build the solution
3. Run the project.
4. Screen will show up with a field to enter URL.
5. Enter the URL and click on search
6. It will return Total Count , Top 10 occuring words and how many times it occured and also show images in form of tiles.

#Custom Validation
- Added a custom field validation attribute "HttpsUrl". It validates if the URL entered is not HTTPS it shows a message to user and ivalidate the form.

#Logging 
- Added logging to record error in "Log-File.txt" and displays a user friendly message to user.

#Library
- Added a Class Library "WebContentExtractor.Common" to keep common code separated and can be extended in future.

#Dsiplay Top 10 Occuring Words
- In web.config there is a key "TopCount" to set the value of results to be shown. Currently it is set to deault value of 10.
