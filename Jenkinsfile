pipeline {
    agent any

    environment {
        DOTNET_VERSION = "8.0"
        SSH_SERVER = "PFS_API" // ชื่อ SSH Server ที่ตั้งไว้ใน Jenkins
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/YEE-SUTTIPORN/PersonalFinanceProject.API.git'
            }
        }

        stage('Restore & Build') {
            steps {
                sh 'dotnet restore PersonalFinanceProjects.API\PersonalFinanceProjects.API.csproj'
                sh 'dotnet publish PersonalFinanceProjects.API\PersonalFinanceProjects.API.csproj -c Release -o publish'
            }
        }

        stage('Deploy to Linux Server') {
            steps {
                sshPublisher(
                    publishers: [
                        sshPublisherDesc(
                            configName: "${SSH_SERVER}",
                            transfers: [
                                sshTransfer(
                                    sourceFiles: 'publish/**',
                                    removePrefix: 'publish',
                                    remoteDirectory: '/var/www/pfs_api',
                                    execCommand: '''
                                        sudo systemctl stop pfs_api
                                        cp -r /var/www/pfs_api/* /var/www/pfs_api-backup/
                                        echo "Files copied"
                                        sudo systemctl start pfs_api
                                    '''
                                )
                            ]
                        )
                    ]
                )
            }
        }
    }
}
