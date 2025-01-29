using UserManagmentSystem.Models.Dtos.Users;

namespace UserManagmentSystem.Service.Abstracts;



public interface IAuthService
{
    Task LoginAsync(LoginRequestDto loginRequestDto);
    Task LogOutAsync();
}
// async - Task - await 
// Arayüz uygulamalarında donmayı önlemek için kullanılır.
// Yüksek performans istediğimiz uygulamalarda kullanıır.

// async
// Bir metodun asenkron bir şekilde çalışacağını belirtir.
// genellikle await ile birlikte kullanılır.

//await
// Asenkron bir işlemin tamamlanmasını beklermek için kullanılır.
// await in kullanılmadığı metodun diğer parçaları işlem tamamlanana kadar çalışmaz. Ana iş parçacığı serbest kalır.


// Task , Task<T>
