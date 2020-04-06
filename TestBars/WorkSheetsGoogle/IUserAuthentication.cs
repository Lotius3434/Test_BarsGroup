using Google.Apis.Auth.OAuth2;

namespace TestBars.WorkSheetsGoogle
{
    /// <summary>
    /// Интерфейс объекта, который отвечает за аутентификацию пользователя.
    /// </summary>
    public interface IUserAuthentication
    {
        /// <summary>
        /// Начинает аутентификацию, создает файл с настройками для соединения с google api.
        /// <para>Если файл соединения создан и настройки scope не изменялись, повторной аутентификации не происходит. </para>
        /// </summary>
        /// <returns>Возврашает файл с настройками api/</returns>
        UserCredential Authentication();
    }
}
