namespace JobFinderAPI.Application.Templates
{
    public static class EmailVerificationBody
    {
        public static string GetVerificationCodeTemplate(string email, string verificationCode)
        {
            return $@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f4f4f4;
                            margin: 0;
                            padding: 0;
                        }}
                        .container {{
                            width: 100%;
                            max-width: 600px;
                            margin: 0 auto;
                            background-color: #ffffff;
                            padding: 20px;
                            border-radius: 8px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        }}
                        .header {{
                            text-align: center;
                            color: #333333;
                        }}
                        .body-text {{
                            font-size: 16px;
                            line-height: 1.5;
                            color: #555555;
                            text-align: center;
                        }}
                        .verification-code {{
                            font-size: 18px;
                            font-weight: bold;
                            color: #ffffff;
                            background-color: #4CAF50;
                            padding: 10px;
                            border-radius: 5px;
                            display: inline-block;
                            margin-bottom: 20px;
                        }}
                        .button {{
                            display: inline-block;
                            background-color: #4CAF50;
                            color: #ffffff;
                            padding: 15px 30px;
                            text-decoration: none;
                            font-size: 16px;
                            border-radius: 5px;
                            margin-top: 20px;
                        }}
                        .button:hover {{
                            background-color: #45a049;
                        }}
                        .footer {{
                            text-align: center;
                            font-size: 14px;
                            color: #777777;
                            margin-top: 20px;
                        }}
                        .footer a {{
                            color: #4CAF50;
                            text-decoration: none;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h2>Email Verification</h2>
                        </div>

                        <div class='body-text'>
                            <p>Thank you for registering with Job Finder!</p>
                            <p>To complete your registration, please verify your email address by clicking the button below or by entering the verification code provided.</p>
                            <p class='verification-code'>
                                 {verificationCode}
                            </p>
                            <br>
                            <a href='https://localhost:5001/api/users/verify/?email={email}&verificationCode={verificationCode}' class='button' style='color: #ffffff; text-decoration: none;'>Verify Your Email</a>
                            <p>If you did not sign up for an account with us, please ignore this email.</p>
                        </div>

                        <div class='footer'>
                            <p>Best regards,<br>The JobFinder</p>
                        </div>
                    </div>
                </body>
                </html>";
        }
    }
}
