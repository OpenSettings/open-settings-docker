# <img src="logo/open-settings-logo.png" alt="Header" width="24"/> OpenSettings [Docker Image](https://hub.docker.com/r/opensettings/open-settings)

Welcome to the official docker repository for [**OpenSettings**](https://opensettings.net)!

OpenSettings is a **centralized settings management** system designed for **.NET applications**. It simplifies app settings management by providing a structured and scalable approach to handling settings.

![Demo](https://github.com/OpenSettings/open-settings-docs/blob/master/docs/v1/assets/gifs/demo.gif)

## 🌍 Online Documentation

The latest OpenSettings documentation is available at [**docs.opensettings.net**](https://docs.opensettings.net)

## 📂 Repository Structure

This repository contains the necessary files and configurations to run OpenSettings as a provider inside a Docker container. It is designed to make deployment easy while ensuring compatibility with various environments.

## 🚀 Getting Started

To contribute or run the documentation locally, follow these steps:

### 1️⃣ Clone the Repository
```sh
git clone https://github.com/OpenSettings/open-settings-docker.git
cd open-settings-docker/
```

### 2️⃣ Run Docker Compose 

Before running the project, ensure that Docker and Docker Compose are installed on your machine. If you're unsure, check the [Docker installation guide](https://docs.docker.com/get-docker/).

Run the following command to bring up the necessary containers:

```sh
docker-compose up
```

### 3️⃣ Navigate to the Url

Once the containers are running, Open your browser and navigate to **[http://localhost:5388](http://localhost:5388)** to preview the OpenSettings! 🚀

### 4️⃣ Configure Database Provider (Optional)

By default, the Docker Compose configuration uses `Sqlite` as the database provider. However, you can choose a different database provider by updating the `docker-compose.yml` file.

```yaml
# Default to Sqlite database (this is active by default)
- OPENSETTINGS_Configuration__DbProviderName=Sqlite
- OPENSETTINGS_Configuration__ConnectionString=Data Source=OpenSettings.db
```

comment out the default `Sqlite` lines and uncomment the database provider you want to use. Be sure to also update the connection string with your own credentials.

## 💡 License  

Licensed under the [OpenSettings License](https://opensettings.net/license).

## 🤝 Contributing

By contributing this repository, you agree to the [Contribution Terms](https://opensettings.net/contribution-terms).

## 🐞 Issues & Reports

If you encounter any issues or have suggestions, please report them via our GitHub repository.

### How to Report an Issue:
1. **Search for Existing Issues**: Check if your issue has already been reported in the [Issues section](https://github.com/OpenSettings/open-settings-docker/issues).
2. **Submit a New Issue**: If not, create a new issue by clicking **"New issue"** on the [Issues page](https://github.com/OpenSettings/open-settings-docker/issues), describing the problem, and including relevant details like steps to reproduce, error messages, and logs.

### Reporting Guidelines:
- Be specific about the issue, including environment and configuration details.
- Include relevant error logs or screenshots if available.

### Security Concerns:
For security-related issues, **do not** use GitHub Issues. Contact us directly at [security@opensettings.net](mailto:security@opensettings.net).

We appreciate your feedback and will address your concerns as soon as possible!

## 🔗 Useful Links

- 🌍 **Website:** [opensettings.net](https://opensettings.net)
- 🌍 **Docs Website:** [docs.opensettings.net](https://docs.opensettings.net)
- ❤️ **Become a Sponsor:** [opensettings.net/become-a-sponsor](https://opensettings.net/become-a-sponsor)
- 📜 **License:** [opensettings.net/license](https://opensettings.net/license)
- ⚖️ **Terms & Conditions:** [opensettings.net/terms-and-conditions](https://opensettings.net/terms-and-conditions)
- 🔒 **Privacy Policy:** [opensettings.net/privacy-policy](https://opensettings.net/privacy-policy)

<br>

✨ *OpenSettings makes settings management simple, powerful, and flexible!* 🚀
