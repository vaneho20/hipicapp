﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationMessages() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.ValidationMessages", typeof(ValidationMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a La competición no es válida.
        /// </summary>
        public static string hipicapp_validator_competition {
            get {
                return ResourceManager.GetString("hipicapp.validator.competition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a La categoría no es válida.
        /// </summary>
        public static string hipicapp_validator_competition_category {
            get {
                return ResourceManager.GetString("hipicapp.validator.competition.category", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe ser menor que Inicio de la competición.
        /// </summary>
        public static string hipicapp_validator_competition_registration_end_date_lt_start_date {
            get {
                return ResourceManager.GetString("hipicapp.validator.competition.registration.end.date.lt.start.date", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe ser menor que Fecha fin de inscripción.
        /// </summary>
        public static string hipicapp_validator_competition_registration_start_date_lt_registration_end_date {
            get {
                return ResourceManager.GetString("hipicapp.validator.competition.registration.start.date.lt.registration.end.date", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe ser menor que Fin de la competición.
        /// </summary>
        public static string hipicapp_validator_competition_start_date_lt_end_date {
            get {
                return ResourceManager.GetString("hipicapp.validator.competition.start.date.lt.end.date", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe tener 6 carácteres como mínimo.
        /// </summary>
        public static string hipicapp_validator_password_pattern {
            get {
                return ResourceManager.GetString("hipicapp.validator.password.pattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a tiene que ser único.
        /// </summary>
        public static string hipicapp_validator_unique {
            get {
                return ResourceManager.GetString("hipicapp.validator.unique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a ya está registrado en Hipicapp.
        /// </summary>
        public static string hipicapp_validator_user_email_unique {
            get {
                return ResourceManager.GetString("hipicapp.validator.user.email.unique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe ser igual que Confirmar nueva contraseña.
        /// </summary>
        public static string hipicapp_validator_user_new_password_not_equal_confirm_new_password {
            get {
                return ResourceManager.GetString("hipicapp.validator.user.new.password.not.equal.confirm.new.password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Ya existe una categoría que incluye este rango de años.
        /// </summary>
        public static string hipicapphipicapp_validator_competition_category_range_of_years {
            get {
                return ResourceManager.GetString("hipicapphipicapp.validator.competition.category.range.of.years", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a valor numérico fuera de los límites (se esperaba &lt;{integer} dígitos&gt;.&lt;{fraction} dígitos).
        /// </summary>
        public static string validator_digits {
            get {
                return ResourceManager.GetString("validator.digits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a no es una dirección de correo bien formada.
        /// </summary>
        public static string validator_email {
            get {
                return ResourceManager.GetString("validator.email", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a tiene que ser una fecha en el futuro.
        /// </summary>
        public static string validator_future {
            get {
                return ResourceManager.GetString("validator.future", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a la longitud tiene que estar entre {Min} y {Max}.
        /// </summary>
        public static string validator_length {
            get {
                return ResourceManager.GetString("validator.length", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe ser menor o igual que {Value}.
        /// </summary>
        public static string validator_max {
            get {
                return ResourceManager.GetString("validator.max", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe ser mayor o igual que {Value}.
        /// </summary>
        public static string validator_min {
            get {
                return ResourceManager.GetString("validator.min", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a no válido.
        /// </summary>
        public static string validator_nif_cif_nie {
            get {
                return ResourceManager.GetString("validator.nif.cif.nie", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a no puede estar vacío.
        /// </summary>
        public static string validator_notEmpty {
            get {
                return ResourceManager.GetString("validator.notEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a no puede estar vacío.
        /// </summary>
        public static string validator_notNull {
            get {
                return ResourceManager.GetString("validator.notNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a no puede ser nulo o vacío.
        /// </summary>
        public static string validator_notNullNotEmpty {
            get {
                return ResourceManager.GetString("validator.notNullNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe ser un valor numérico.
        /// </summary>
        public static string validator_numeric {
            get {
                return ResourceManager.GetString("validator.numeric", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a tiene que ser una fecha en el pasado.
        /// </summary>
        public static string validator_past {
            get {
                return ResourceManager.GetString("validator.past", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe coincidir con &quot;{Regex}&quot;.
        /// </summary>
        public static string validator_pattern {
            get {
                return ResourceManager.GetString("validator.pattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe estar entre {Min} and {Max}.
        /// </summary>
        public static string validator_range {
            get {
                return ResourceManager.GetString("validator.range", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a pueden tener un contenido html inseguro.
        /// </summary>
        public static string validator_safeHtml {
            get {
                return ResourceManager.GetString("validator.safeHtml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a la longitud tiene que estar entre {Min} y {Max}.
        /// </summary>
        public static string validator_size {
            get {
                return ResourceManager.GetString("validator.size", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe ser una dirección URL válida.
        /// </summary>
        public static string validator_URL {
            get {
                return ResourceManager.GetString("validator.URL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a debe estar dentro de {Min} y {Max}.
        /// </summary>
        public static string validator_within {
            get {
                return ResourceManager.GetString("validator.within", resourceCulture);
            }
        }
    }
}
