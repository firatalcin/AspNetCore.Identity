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
