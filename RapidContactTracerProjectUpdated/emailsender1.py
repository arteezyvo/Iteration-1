#version: read sql file by itself
import csv
import smtplib
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText
from apscheduler.schedulers.blocking import BlockingScheduler
from datetime import date
import sys
import getpass

#import pyodbc 

#Info of my gmail 
my_address = input("Email address: ")
my_password = getpass.getpass('Password:')

sql_file = input("sqlfile ") #example 'dbo.Users.data.sql'
 
#create the message
from string import Template
def read_msg(filename):
    with open(filename, 'r', encoding = 'utf-8') as file:
        file_content = file.read()
    return file_content 
 
#make a list of address and passwords
def get_contacts(): #for example we have the simplest list generated from the seating chart like this with mixed students. 
                    #True means we will send email, false means we will not
    listName= []
    with open(sql_file,'r') as f:
        lines = [line.strip() for line in f if line.strip()]
        for n in lines:
            if (len(n.split('VALUES'))) >1:
                person_name = n.split('VALUES')[1].split(',')[1][3:-1]
                person_email = n.split('VALUES')[1].split(',')[3][3:-1]
                a = '{} {}'.format(person_name, person_email)
                listName.append(a)
    print(listName)
    return listName
    

def send_email():
    #get the message and contact
    #ori_mesage = read_msg(r"C:\Users\huynh\OneDrive\Máy tính\message.txt") #replace this location by the location of the text file that you downloaded
    name_list = get_contacts()
    
    
    #log in
    #my_address = address.get()
    #my_password = password.get()
    s = smtplib.SMTP('smtp-mail.outlook.com',587)
    s.ehlo()
    s.starttls()
    s.ehlo()
    s.login(my_address, my_password)
    #print("login successful")

    
    #get the address and password
    numEmail = 0
    for i in name_list:
        name, email_address = i.split()
        msg = MIMEMultipart()# create a message
        
        
        # replace the filler name by the person name 
        ori_mesage = "Dear PERSON_NAME, \n \n In the last few days you have contacted with someone that had covid-19. The below is the information of testing centers. Thank you \n \n CVS pharmacy \n Address: 318 West Beauregard, San Angelo, TX 76903 \n Phone: (325) 653-4289 \n San Angelo VA Clinic \n Address: 4240 Southwest Blvd, San Angelo, TX 76904 \n Phone: (325) 658-6138 \n \n Have a great day, PERSON_NAME! \n Developer team \n RCP - Rapid Contact Tracing"
        message = ori_mesage.replace('PERSON_NAME', name)
        #set the sender and receiver email addresses, and set the header
        msg['From'] = my_address
        msg['To'] = email_address
        msg['Subject'] = "Alert, covid19"
        #attach the message
        msg.attach(MIMEText(message))
        #send email
        s.sendmail(my_address,email_address,msg.as_string())
        numEmail+=1
    

    
    # Terminate the SMTP session and close the connection
    s.quit()
    #inform when get the job done
    today = date.today()
    print("Today is ", today, ", we sent emails to ", numEmail, "students" )

def main():
    scheduler = BlockingScheduler()
    scheduler.add_job(send_email, 'interval', hours=24)
    scheduler.start()
#if __name__ == "__main__":  # single underscore
#    main()
def init():
    if __name__ == "__main__":
        sys.exit(main())
init()

import mock
import pytest
def test_init():
    from myapp import module
    with mock.patch.object(module, "main", return_value=42):
        with mock.patch.object(module, "__name__", "__main__"):
            with mock.patch.object(module.sys,'exit') as mock_exit:
                module.init()
                assert mock_exit.call_args[0][0] == 42

                