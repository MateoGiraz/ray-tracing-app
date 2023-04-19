﻿using Controller.ClientExceptions;
using IRepository;
using MemoryRepository;
using MemoryRepository.Exceptions;
using Models;


namespace Controller
{
    public class ClientController
    {
        private const string WrongPasswordMessage = "Wrong email or password";
        public IRepositoryClient Repository;
        public ClientController()
        {
            Repository = new ClientRepository();
        }

        public void SignUp(string username, string password)
        {
            try
            {
                RunSignUpChecker(username, password);
                Repository.AddClient(username, password);
            }
            catch (InvalidCredentialsException ex)
            {
                throw new InvalidCredentialsException(ex.Message);
            }
        }

        private void RunSignUpChecker(string username, string password)
        {
            if (ClientAlreadyExists(username))
            {
                string AlreadyExsitingClientMessage = $"Client with username {username} already exists";
                throw new AlreadyExistingClientException(AlreadyExsitingClientMessage);
            }

            ClientValidator.RunPasswordConditions(password);
            ClientValidator.RunUsernameConditions(username);
        }

        public bool ClientAlreadyExists(string username)
        {
            try
            {
                Repository.GetClient(username);
                return true;
            }
            catch (NotFoundClientException)
            {
                return false;
            };
        }

        public Client SignIn(string username, string password)
        {
            try
            {
                RunSignInChekcer(username, password);
                return Repository.GetClient(username);
            }
            catch (InvalidCredentialsException ex)
            {
                throw new InvalidCredentialsException(ex.Message);
            }

        }

        private void RunSignInChekcer(string username, string password)
        {
            try
            {
                string _clientPassword = Repository.GetClient(username).Password;

                if (!_clientPassword.Equals(password))
                {
                    throw new NotCorrectPasswordException(WrongPasswordMessage);
                }
            }
            catch (NotFoundClientException)
            {
                throw new NotCorrectPasswordException(WrongPasswordMessage);
            }
        }

        public void SignOut(ref Client currentClient)
        {
            currentClient = null;
        }

        public bool IsLoggedIn(Client currentClient)
        {
            return currentClient is object;
        }
    }
}
