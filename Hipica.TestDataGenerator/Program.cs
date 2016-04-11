namespace Hipica.TestDataGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*IApplicationContext ctx = ContextRegistry.GetContext();
            IUserService accountService = ServiceLocator.LocateService<IUserService>(ServiceNames.ACCOUNT_SERVICE);
            IStoreItemService itemService = ServiceLocator.LocateService<IStoreItemService>(ServiceNames.STOREITEM_SERVICE);
            IComposerService composerService = ServiceLocator.LocateService<IComposerService>(ServiceNames.COMPOSER_SERVICE);
            IEditorService editorService = ServiceLocator.LocateService<IEditorService>(ServiceNames.EDITOR_SERVICE);
            IInstrumentService instrumentService = ServiceLocator.LocateService<IInstrumentService>(ServiceNames.INSTRUMENT_SERVICE);
            ISubscriptionLevelService subscriptionLevelService = ServiceLocator.LocateService<ISubscriptionLevelService>(ServiceNames.SUBSCRIPTION_LEVEL_SERVICE);
            IRepertoireService repertoireService = ServiceLocator.LocateService<IRepertoireService>(ServiceNames.REPERTOIRE_SERVICE);
            IMusicalStudyLevelService musicalStudyLevelService = ServiceLocator.LocateService<IMusicalStudyLevelService>(ServiceNames.MUSICAL_STUDY_LEVEL_SERVICE);

            var rand = new Random();

            // Creamos instrument
            IList<SubscriptionLevel> subscriptionLevels = Builder<SubscriptionLevel>.CreateListOfSize(3).All().Build();
            subscriptionLevels[0].Price = 0;
            subscriptionLevels[0].Name = "Free";
            subscriptionLevels[1].Name = "Amateur";
            subscriptionLevels[2].Name = "Soloist";
            subscriptionLevelService.Save(subscriptionLevels);

            // Creamos las cuentas de usuario
            IList<User> accounts = Builder<User>.CreateListOfSize(10).All().Build();
            IList<Subscription> subscriptions = new List<Subscription>(1);
            int index = 0;
            foreach (User u in accounts)
            {
                u.UserName = string.Concat(u.UserName, "@izertis.com");
                u.Password = CryptographyUtil.Encrypted(u.Password);
                u.Subscriptions = new List<Subscription>(1);
                Subscription s = new Subscription();
                s.SubscriptionDate = DateTime.Now;
                s.SubscriptionLevel = subscriptionLevels[rand.Next(subscriptionLevels.Count)];
                s.Price = s.SubscriptionLevel.Price;
                s.User = u;
                subscriptions.Add(s);
                index++;
            }
            accountService.Save(accounts);
            accountService.Save(subscriptions);

            // Creamos compositores
            IList<Composer> composers = Builder<Composer>.CreateListOfSize(20).All().Build();
            composerService.Save(composers);

            // Creamos editors
            IList<Editor> editors = Builder<Editor>.CreateListOfSize(10).All().Build();
            editorService.Save(editors);

            // Creamos instrument
            IList<Instrument> instruments = Builder<Instrument>.CreateListOfSize(20).All().Build();
            instrumentService.Save(instruments);

            // Creamos piezas
            IList<Piece> pieces = Builder<Piece>.CreateListOfSize(400).All().With(x => x.Id = null).Build();

            foreach (Piece p in pieces)
            {
                p.Editor = editors[rand.Next(editors.Count)];
                p.Composer = composers[rand.Next(composers.Count)];
            }
            itemService.Save<Piece>(pieces);

            // Creamos colecciones
            IList<Collection> collections = Builder<Collection>.CreateListOfSize(20).All().With(x => x.Id = 401).Build();
            pieces = itemService.GetAll<Piece>();

            IList<CollectionPiece> collectionPieces = new List<CollectionPiece>(400);
            index = 0;
            int bIndex = 0;
            int cIndex = 0;
            foreach (Collection c in collections)
            {
                c.Editor = editors[rand.Next(editors.Count)];
                c.Id = c.Id + cIndex;
                itemService.Save(c);
                foreach (Piece p in pieces)
                {
                    if (!((index - (bIndex - 1)) == 20))
                    {
                        CollectionPiece cp = new CollectionPiece();
                        cp.Collection = c;
                        cp.Piece = pieces[index];
                        collectionPieces.Add(cp);
                        index++;
                    }
                    else
                    {
                        bIndex = index;
                        break;
                    }
                }
                cIndex++;
            }
            itemService.Save(collectionPieces);

            // Creamos repertoires
            index = 0;
            bIndex = 0;
            cIndex = 0;
            IList<Repertoire> repertoires = Builder<Repertoire>.CreateListOfSize(20).All().Build();
            IList<RepertoirePiece> repertoirePieces = new List<RepertoirePiece>(20);
            foreach (Repertoire r in repertoires)
            {
                r.User = accounts[rand.Next(accounts.Count)];
                foreach (Piece p in pieces)
                {
                    if (!((index - (bIndex - 1)) == 20))
                    {
                        RepertoirePiece rlp = new RepertoirePiece();
                        rlp.Collection = collections[cIndex];
                        rlp.Piece = pieces[index];
                        rlp.Repertoire = r;
                        repertoirePieces.Add(rlp);
                        index++;
                        cIndex++;
                    }
                    else
                    {
                        cIndex = 0;
                        bIndex = index;
                        break;
                    }
                }
            }
            repertoireService.Save(repertoires);
            repertoireService.Save(repertoirePieces);

            IList<MusicalStudyLevel> levels = Builder<MusicalStudyLevel>.CreateListOfSize(3).Build();
            musicalStudyLevelService.Save(levels);*/
        }
    }
}