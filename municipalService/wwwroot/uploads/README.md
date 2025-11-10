# The Secure Customer International Payments Portal

## BY: 
## Fabian Jefferies - ST10154493.
## Saien Govender - ST10133334.
## Uraysha Reddy - ST10306658.
## Banele Sobantu - ST10242025.
##
## GITHUB LINK: https://github.com/IIEWFL/insy7314-part-2-f-s-u-b.git
## Youtube Video LINK: https://youtu.be/cAZmfneoc9A
##
### The How To Guide:
##
### What do i need:
#
####  Visual Studio.
####  Mongo DB Atlas Account and a Cluster created within.
#
### Downloading the files and getting them ready:
#
#### Step 1: Download the zip file from the GitHub repository called Customer International Payments Portal.

#### Step 2: Once you have downloaded the file you will need to unzip the file.
#
### Opening the file in VS (Visual Studio), preparing it to run:
#
#### Step 1: Open Visual Studio (VS) and open the unzipped file.

#### Step 2: Once the file is open in VS, you will need to create a .env file in the backend folder, in which you will need to enter your MongoDB Atlas
#### Place the code below in your .env folder and fill in your own Mongo bd cluster connection string after  "MONGODB_URI=" as seen below then underneath that "PORT=8000" as seen below then the use "USE_HTTPS=false" under that an then "JWT_SECRET=" and your name and surname as directed below in FIGURE 1.
#
### FIGURE 1:
#### MONGODB_URI= mongodb+srv://YourNameHere:YourClusterPassword@vccluster.aqozapg.mongodb.net/?retryWrites=true&w=majority&appName=VCCluster
#### PORT=8000
#### USE_HTTPS=false
#### JWT_SECRET= your name and surname here like so eg, johnsmith

#### Step 3: you will then need to open a comandpromt terminal and in the backend folder install followoing dependences as displayed bellow in FIGURE 2: 

### FIGURE 2: 
#### Npm installs
#
#### Backend:
#### npm init -y
#### npm i dotenv
#### npm i -D nodemon 
#### npm i express 
#### npm i mongodb mongoose 
#### npm i bcrypt 
#### npm i jsonwebtoken
#### npm i express-validator 
#### npm i cors 
#
#### Once you have installed all the above dependincies you can run the server using "npm run dev". And keep it running DO NOT CLOSE THE TERMINAL.
#
#### Step 4: Open a new command Pormt terminal and in the frontend run the below commands.
#
#### Frontend: npm install
#### npm install axios react-router jwt-decode tailwindcss@latest @tailwindcss/vite@latest daisyui@latest  
#### npm i react-router-dom
#
#### Once you have installed all the above dependincies you can run the front using "npm run dev". DO NOT CLOSE THE TERMINAL.
#

#### Running the The Secure Customer International Payments Portal:
#
#### Step 1: Make sure both your Backend anf Frontend terminals are Running.
#### Step 2: Oce bothe the back and front end are running you will then go into the frontend terminal and control + click on the link in the terminal that says  "Local:  http://localhost:5173/" this will open brower to the Customer International Payments Portal.
#### Step 3: Now that the Customer International Payments Portal is open you can use the system.
#

### How do i use the Customer International Payments Portal system:

#### Step 1: first register you self by entering you detail in to the correct text boxes: us FIGURE 3 below as a guide. once all felids are filled correctly 

#### FIGURE 3:
#
#### Username
#### eg. John Doe (more than 5 letters)
#### Email
#### eg. your@gmail.com
#### ID Number
#### eg. 1234567890123 (must be 13 Characters)
#### Account Number
#### eg. 1234567890 (must be 10 Characters)
#### Password
#### eg. yourPassword
#### Confirm Password
#### eg. ConfirmedyourPassword
####
#
#### Step 2: is to login with you username and selected password.
#### Step 3: in to compleat the swift payment form. Use FIGURE 4 as a reference.
#
#### FIGURE 4:
#
#### Enter an amount you wish to pay.
#### Select a currency in which you would like to pay.
#### Type out you personal provide.
#### Input the payees account number.
#### And enter you SWIFT code.
#### and submit by clicking Pay Now.
##
#### Step 4: dont forget to logout of your account for security.
##
## Thank you for using The Secure Customer International Payments Portal.






















