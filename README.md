# AspNetCore.Identity

<h2>Asp.Net Core Identity Nedir ?</h2>

<p>Asp.Net uygulamalarında üyelerin erişebilirliğiyle ilgili geniş kapsama sahip olmakla birlikte yönetilebilirlik açısından daha derin, daha esnek ve sınırsız özelleştirilebilme niteliğine sahip olan bir üyelik sistemi framework'üdür.</p>
<p>Asp.Net Core Identity; Üyelerin, giriş, çıkış, yetkilendirme, token, şifre hatırlatma vs. işlemlerini hızlı bir şekilde gerçekleştirmemizi sağlayan ve bunların dışında önceki nesillere nazaran herhangi bir kısıtlaması olmaksızın uygulamalarımızı destekleyen modern bir üyelik sistemidir. Gündümüzdeki üçüncü kaynaklardan sağlanan modern oturum süreçlerini(Facebook Login, Google Login, Twitter Login vs.) desteklemekte ve tüm inşayı hızlı bir şekilde gerçekleştirmektedir.</p>
<p>Asp.NET Core Identity kütüphanesinin en büyük özelliği esnek olmasıdır. Bize sağladığı özellikler tarafımızca beğenilmez veya daha iyisi yapılabileceği düşünülürse, custom olarak bu sistemleri inşa etmemize olanak sağlar.</p>

<h2>Temel Kavramlar</h2>

<ul>
    <li><b>Authentication</b></li>
    <p>Kullanıcının sistem tarafından tanımlanan kişi olup olmadığının doğrulanmasıdır. Bir başka deyişle kimlik doğrulamasıdır.</p>
    <li><b>Authorization</b></li>
    <p>Sistemde doğrulanan kullanıcının hangi sınırlara sahip olduğunun belirlenmesidir. Bunada da kimlik yetkilendirmesi diyebiliriz.</p>
    <li><b>Claims</b></li>
    <p>Doğrulanmış kullanıcıya açılmış oturum üzerinde kullanıcı kendisine has bilgileri Claims yapısı aracılığıyla tutabilmektedir. Örneğin; kullanıcı adı ve şifre ile doğrulanmış kullanıcının kişiselleştirilmiş bilgileri claim ile o oturumda taşıyabilmekteyiz.</p>
    <li><b>Third Party Authentication</b></li>
    <p>Üçüncü taraf kimlik doğrulamadır. Facebook, Google, Twitter vs. gibi hesaplarla sistemler üzerinden gerçekleştirilen kimlik doğrulamasıdır.</p>
</ul>

<h2>Asp.Net Core Identity - Identity Altyapısı Kurulumu</h2>

<p>Identity'i kütüphanesini bir projede kullanabilmek için öncelikle ilgili Nuget'leri(Package) indirmemiz gerekmektedir.</p>

<ul>
    <li>Microsoft.AspNetCore.Identity.EntityFrameworkCore</li>
    <li>Microsoft.EntityFrameworkCore.Design</li>
    <li>Microsoft.EntityFrameworkCore.Tools</li>
    <li>Microsoft.EntityFrameworkCore.SqlServer</li>
</ul>

<h2>En Temel Identity Sınıfları</h2>

<p>Asp.Net Core Identity kütüphanesinde en temek aktörler IdentityUser ve IdentityRole sınıflarıdır. Bu sınıflar hali hazırda Identity kütüpnesinin içinde bulunup birçok propery içermektedir.</p>
<p>IdentityUser ve IdentityRole sınıflarına istediğimiz propery'leri eklemek için bu sınıfları miras alan AppUser ve AppRole sınıfları oluşturulur</p>

<ul>
    <li>public class AppUser : IdentityUser {}</li>
    <li>public class AppRole : IdentityRole {}</li>
</ul>

<p>Identity kütüphanesi ile oluşturulmuş bir veritabanı tasarlamak için bir Context sınıfı oluşturulmalıdır. Oluşturulan Context sınıfı EntityFrameworkCore ile gelen DbContext sınıfını miras almak yerine IdentityDbContext sınıfını miras almalıdır.</p>

<ul>
    <li>public class AppDbContext : IdentityDbContext<AppUser> {} </li>
</ul>

<p>Projede Identity'i kullanabilmek için Program.cs dosyasına bir servis olarak eklenmelidir.</p>

<ul>
    <li>services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();</li>
</ul>

<p>Bu yapıda ilgili migrate işlemlerini yaptıktan sonra Identity tabanlı ve ilgili default tablolarıyla beraber bir veritabanının kurulduğunu görüyoruz.</p>

<ul>
    <li>AspNetRoleClaims</li>
    <li>AspNetRoles</li>
    <li>AspNetUserClaims</li>
    <li>AspNetUserLogins</li>
    <li>AspNetUserRoles</li>
    <li>AspNetUsers</li>
    <li>AspNetUserTokens</li>
</ul>

<h2>Tablo Detayları</h2>

<h3>AspNetUsers</h3>

<ol>
    <li>Id : Her bir kullanıcıyı temsil edecek olan PrimaryKey Id değeridir.</li>
    <li>UserName, NormalizedUserName : Kullanıcı adını tutan kolondur. NormalizedUserName kolonu milyonluk/milyarlık verilerde(Big Data) arama sorgularını gerçekleştirirken hız kazanmak için oluşturulmuş bir kolondur. Çünkü Normalized ile başlayan kolonlar indekslenmiştir. Normalized kolonlar tek bir türde veri tutarlar. Örneğin UserName alanına 'Fırat' dediğiniz zaman NormalizedUserName alanına 'FIRAT' yazılır. Bu da sorgulara hız kazandırır.</li>
    <li>Email, NormalizedEmail : Kullanıcının e-posta bilgisini tutan kolondur. Aynı şekilde NormalizedEmail ise indekslenmiş halidir.</li>
    <li>PasswordHash : Kullanıcıdan alınan tüm passwordler Hash algoritmasıyla şifrelenerek tutulmaktadır.</li>
    <li>SecurityStamp : Kullanıcı ilk oluşturulduğunda(create) buraya bir build değeri atanır. Sonraki her güncelleme üzerine bu değer güncellenecektir. Dolayısıyla bizlerde bu kullanıcı üzerinde bir değişiklik olduğuna dair bilgi edinmiş olacağız. Bir nevi Data Concurrency sağlayabilmek için oluşturulmuştur.</li>
    <li>ConcurrencyStamp : İlgili veri üzerinde Data Concurrency sağlayabilmek için oluşturulmuştur.</li>
    <li>TwoFactorEnabled : Kullanıcının kaydı neticesinde aktivasyon yapılanmasının iki adımlı olup olmadığına dair kayıt tutar. Bu kolon genellikle 3. party üyelik sistemleriyle birlikte kullanılır. Örneğin; kullanıcı Facebook üzerinden giriş yaptığında ekstradan telefon ile onay gerektiriyorsa işte “TwoFactorEnabled” kolonu true/1 olarak işaretlenecektir.</li>
    <li>LockoutEnd, LockoutEnabled, AccessFailedCount : Kullanıcı girişlerine dair yapılan hataları ve engel durumunu tutan kolonlardır. “LockoutEnd” kolonu kaç kez yanlış girildiğine dair, “LockoutEnabled” kolonu kullanıcının aktifliğine dair ve “AccessFailedCount” kolonu ise kaç başarısız giriş yapılmaya çalışıldığına dair bilgi tutmaktadır. Identity mimarisi bu yapıları otomatik işleyecektir. Dolayısıyla tarafımızca custom bir kod geliştirmemize gerek yoktur.</li>
</ol>

<h3>AspNetRoles</h3>

<p>Uygulamada kullanıcılara özgü tanımlanan rolleri tutan tablodur. Tabloyu incelersek rollerin adını tutacak olan <b>Name</b> kolonu ve bu değerleri indexleyip big data durumlarında performans kazandıracak indexlenmiş <b>NormalizedName</b> kolonu mevcuttur. Ayrıca veri tutarlılığı içinde <b>ConcurrencyStamp</b> kolunu mevcuttur.</p>

<h3>AspNetUserRoles</h3>

<p>Uygulamada hangi kullanıcı hangi rol yetkilerine sahip ilişkilendiren Cross Table(Ara Tablo) görevi gören bir tablodur. Composite primary key olarak ayarlanan <b>UserId</b> ve <b>RoleId</b> kolonları üzerinden bu ilişki sağlanmaktadır.</p>

<h3>AspNetUserClaims</h3>

<p>Kullanıcılara dair ekstra bilgiler bu tabloda tutulmaktadır.</p>

<h3>AspNetRoleClaims</h3>

<p>Uygulamada tanımlanan rollere dair ekstra bilgiler bu tabloda tutulmaktadır.</p>

<h3>AspNetUserLogins</h3>

<p>3. party üyelik sistemlerinde diğer platformdaki kullanıcıya ait id değerini bu tabloda tutmaktadır. Bu tablo otomatik olarak Identity mimarisi tarafından işlenmektedir.</p>

<h3>AspNetUserTokens</h3>

<p>Token bazlı doğrulamalarda üretilen token değeri bu tabloda tutulur.</p>
