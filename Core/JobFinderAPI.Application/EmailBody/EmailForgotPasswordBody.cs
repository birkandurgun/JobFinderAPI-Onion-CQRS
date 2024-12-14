namespace JobFinderAPI.Application.EmailBody
{
    public static class EmailForgotPasswordBody
    {
        public static string GetForgotPasswordCodeTemplate(string resetToken)
        {
            return $@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Password Reset Request</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            margin: 0;
                            padding: 0;
                            background-color: #f4f4f4;
                            color: #333;
                        }}
                        .container {{
                            width: 100%;
                            max-width: 600px;
                            margin: 20px auto;
                            padding: 20px;
                            background-color: #fff;
                            border-radius: 8px;
                            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
                        }}
                        .header {{
                            background-color: #0073e6;
                            color: white;
                            padding: 10px;
                            border-radius: 6px 6px 0 0;
                            text-align: center;
                        }}
                        .content {{
                            padding: 20px;
                            font-size: 16px;
                        }}
                        .button {{
                            display: inline-block;
                            padding: 10px 20px;
                            margin: 20px 0;
                            background-color: #0073e6;
                            color: white;
                            text-decoration: none;
                            border-radius: 5px;
                            font-weight: bold;
                        }}
                        .footer {{
                            text-align: center;
                            font-size: 12px;
                            color: #777;
                            margin-top: 30px;
                        }}
                        .footer a {{
                            color: #0073e6;
                            text-decoration: none;
                        }}
                    </style>
                </head>
                <body>
                    <div class=""container"">
                        <div class=""header"">
                            <h2>Password Reset Request</h2>
                        </div>
                        <div class=""content"">
                            <p>Hello,</p>
                            <p>You requested to reset your password. Please use the following token to reset your password:</p>
                            <p><strong>Reset Token:</strong> {resetToken}</p>
                            <p>This token is valid for 1 hour.</p>
                            <p>If you did not request this, please ignore this email.</p>
                        </div>
                        <div class=""footer"">
                            <p>Thank you, <br> JobFinderAPI</p>
                        </div>
                    </div>
                </body>
                </html>
                ";
        }
    }
}
