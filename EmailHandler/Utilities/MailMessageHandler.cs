using EmailHandler.Models;

namespace EmailHandler.Utilities
{
    public static class MailMessageHandler
    {
        public static string GetHtmlTemplateForUserregistration(Activity activity)
        {
            string myString = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            text-align: center;
            color: #333333;
        }

        .container {
            max-width: 600px;
            margin: 20px auto;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #004080;
            margin-bottom: 20px;
        }

        p {
            color: #666666;
            margin-bottom: 10px;
        }

        .banner {
            width: 100%;
            max-height: 150px;
            object-fit: cover;
            border-radius: 10px 10px 0 0;
        }

        .content {
            padding: 20px;
        }

        .button {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            text-decoration: none;
            background-color: #004080;
            color: white;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <img src=""https://www.thecommencementgroup.com/wp-content/uploads/2016/02/gstate.png"" alt=""Banner Image"" class=""banner"">
    <div class=""container"">
        <div class=""content"">
            <h1>Welcome to Our Community!</h1>
            <p>Dear {{UserName}},</p>
            <p>Thank you for joining our community. We're thrilled to have you as a new member!</p>
            <p>Your account has been successfully registered.</p>
            <p>We look forward to sharing exciting updates and Activitys with you. Feel free to explore our platform.</p>
            <a href=""{{RedirectURL}}"" class=""button"">Explore Now</a>
        </div>
    </div>
</body>
</html>

";

            myString = myString.Replace("{{UserName}}", activity.UserName);
            myString = myString.Replace("{{RedirectURL}}", activity.RedirectUrl);

            return myString;
        }

        public static string GetHtmlTemplateForActivityRegistration(Activity activity)
        {

            var result = @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            text-align: center;
            color: #333333;
        }

        .container {
            max-width: 600px;
            margin: 20px auto;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #004080;
            margin-bottom: 20px;
        }

        p {
            color: #666666;
            margin-bottom: 10px;
        }

        ul {
            list-style: none;
            padding: 0;
            margin: 0;
        }

        li {
            margin-bottom: 10px;
        }

        .banner {
            width: 100%;
            max-height: 150px;
            object-fit: cover;
            border-radius: 10px 10px 0 0;
        }

        .content {
            padding: 20px;
        }

        .button {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            text-decoration: none;
            background-color: #004080;
            color: white;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <img src=""https://www.thecommencementgroup.com/wp-content/uploads/2016/02/gstate.png"" alt=""Banner Image"" class=""banner"">
    <div class=""container"">
        <div class=""content"">
            <h1>Activity Registration Confirmation</h1>
            <p>Dear {{User}},</p>
            <p>Thank you for registering for our Activity. We are excited to have you on board!</p>
            <p>Activity Details:</p>
            <ul>
                <li><strong>Activity Name:</strong> {{ActivityName}}</li>
                <li><strong>Date:</strong> {{ActivityDate}}</li>
                <li><strong>Location:</strong> {{ActivityLocation}}</li>
            </ul>
            <p>We look forward to seeing you there!</p>
            <a href=""{{RedirectURL}}"" class=""button"">Visit Our App</a>
        </div>
    </div>
</body>
</html>
";

            result = result.Replace("{{User}}", activity.UserName);
            result = result.Replace("{{RedirectURL}}", activity.RedirectUrl);
            result = result.Replace("{{ActivityName}}", activity.ActivityName);
            result = result.Replace("{{ActivityDate}}", activity.ActivityDate.ToString());
            result = result.Replace("{{ActivityLocation}}", activity.ActivityLocation);

            return result;
        }

        public static string GetHtmlTemplateForActivityRegistrationCancellation(Activity activity)
        {
            var result = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            text-align: center;
            color: #333333;
        }

        .container {
            max-width: 600px;
            margin: 20px auto;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #d9534f;
            margin-bottom: 20px;
        }

        p {
            color: #666666;
            margin-bottom: 10px;
        }

        .banner {
            width: 100%;
            max-height: 150px;
            object-fit: cover;
            border-radius: 10px 10px 0 0;
        }

        .content {
            padding: 20px;
        }

        .button {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            text-decoration: none;
            background-color: #d9534f;
            color: white;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <img src=""https://www.thecommencementgroup.com/wp-content/uploads/2016/02/gstate.png"" alt=""Banner Image"" class=""banner"">
    <div class=""container"">
        <div class=""content"">
            <h1>Activity Attendance Canceled</h1>
            <p>Dear {{User}},</p>
            <p>We regret to inform you that your attendance to the following activity has been canceled:</p>
            <p><strong>Activity Name:</strong> {{ActivityName}}</p>
            <p><strong>Date:</strong> {{ActivityDate}}</p>
            <p><strong>Location:</strong> {{ActivityLocation}}</p>
            <p>If you have any questions or concerns, please feel free to reach out to us.</p>
            <p>We hope to see you at future Activitys!</p>
            <a href=""{{RedirectURL}}"" class=""button"">Explore More Activities</a>
        </div>
    </div>
</body>
</html>

";

            result = result.Replace("{{User}}", activity.UserName);
            result = result.Replace("{{RedirectURL}}", activity.RedirectUrl);
            result = result.Replace("{{ActivityName}}", activity.ActivityName);
            result = result.Replace("{{ActivityDate}}", activity.ActivityDate.ToString());
            result = result.Replace("{{ActivityLocation}}", activity.ActivityLocation);

            return result;
        }

        public static string GetHtmlTemplateForActivityEnrollment(Activity activity)
        {
            var result = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            text-align: center;
            color: #333333;
        }

        .container {
            max-width: 600px;
            margin: 20px auto;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #004080;
            margin-bottom: 20px;
        }

        p {
            color: #666666;
            margin-bottom: 10px;
        }

        .banner {
            width: 100%;
            max-height: 150px;
            object-fit: cover;
            border-radius: 10px 10px 0 0;
        }

        .content {
            padding: 20px;
        }

        .button {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            text-decoration: none;
            background-color: #004080;
            color: white;
            border-radius: 5px;
        }

        ul {
            list-style: none;
            padding: 0;
            margin: 0;
        }

        li {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <img src=""https://www.thecommencementgroup.com/wp-content/uploads/2016/02/gstate.png"" alt=""Banner Image"" class=""banner"">
    <div class=""container"">
        <div class=""content"">
            <h1>New Activity Created</h1>
            <p>Dear {{User}},</p>
            <p>Congratulations! You've successfully created a new activity in our system.</p>
            <p>Activity Details:</p>
            <p><strong>Activity Name:</strong> {{ActivityName}}</p>
            <p><strong>Date:</strong> {{ActivityDate}}</p>
            <p><strong>Location:</strong> {{ActivityLocation}}</p>
            <p>Your activity has been registered, and we look forward to its success!</p>
            <a href=""{{RedirectURL}}"" class=""button"">View Activity</a>
        </div>
    </div>
</body>
</html>

";

            result = result.Replace("{{User}}", activity.UserName);
            result = result.Replace("{{RedirectURL}}", activity.RedirectUrl);
            result = result.Replace("{{ActivityName}}", activity.ActivityName);
            result = result.Replace("{{ActivityDate}}", activity.ActivityDate.ToString());
            result = result.Replace("{{ActivityLocation}}", activity.ActivityLocation);

            return result;
        }
    }
}
