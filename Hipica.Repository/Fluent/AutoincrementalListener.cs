using NHibernate.Event;
using System;

namespace Hipica.Repository.Fluent
{
    public class AutoincrementalListener : IPreInsertEventListener
    {
        public bool OnPreInsert(PreInsertEvent evt)
        {
            ///Autoincremental annotation = evt.Entity.GetType().getAnnotation(Autoincremental.class);

            Type type = evt.Entity.GetType();

            do
            {
                //annotation = type.getAnnotation(Autoincremental.class);

                type = type.BaseType;
            } while (/*(annotation == null) && */(type != null));

            /*if (annotation != null)
            {
                String incrementalPropertyValue = null;
                try
                {
                    incrementalPropertyValue = BeanUtils.getNestedProperty(evt.Entity,
                            annotation.incrementalProperty());
                }
                catch (IllegalAccessException e)
                {
                    throw new HibernateException(e);
                }
                catch (InvocationTargetException e)
                {
                    throw new HibernateException(e);
                }
                catch (NoSuchMethodException e)
                {
                    throw new HibernateException(e);
                }

                if (incrementalPropertyValue == null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT MAX(");
                    sb.Append(annotation.incrementalColumn());
                    sb.Append(") FROM ");
                    sb.Append(((AbstractEntityPersister)evt.Persister).RootTableName);

                    annotation.dependantColumns();
                    if ((annotation.dependantColumns() != null) && (annotation.dependantColumns().length > 0))
                    {
                        sb.Append(" WHERE ");
                        for (int i = 0; i < annotation.dependantColumns().length; i++)
                        {
                            sb.Append(annotation.dependantColumns()[i].concat("="));
                            try
                            {
                                String dependantPropertyValue = BeanUtils.getNestedProperty(evt.Entity,
                                        annotation.dependantProperties()[i]);
                                sb.Append('\'').Append(dependantPropertyValue).Append('\'');
                            }
                            catch (IllegalAccessException e)
                            {
                                throw new HibernateException(e);
                            }
                            catch (InvocationTargetException e)
                            {
                                throw new HibernateException(e);
                            }
                            catch (NoSuchMethodException e)
                            {
                                throw new HibernateException(e);
                            }

                            if (i != (annotation.dependantColumns().length - 1))
                            {
                                sb.Append(" AND ");
                            }
                        }
                    }

                    /*if (LOGGER.isDebugEnabled()) {
                        LOGGER.debug(evt.Entity.GetType().getSimpleName() + "." + annotation.incrementalProperty()
                                + " = " + sb.ToString());
                    }*/

            /*ISQLQuery query = evt.Session.CreateSQLQuery(sb.ToString());

            Int32 id = 1;

            if (query.UniqueResult() != null)
            {
                id = Int32.Parse(query.UniqueResult().ToString()) + 1;
            }

            try
            {
                BeanUtils.setProperty(evt.Entity, annotation.incrementalProperty(), id);
                if (evt.Id != null)
                {
                    BeanUtils.setProperty(evt.Id, annotation.incrementalProperty(), id);
                }

                /*if (LOGGER.isDebugEnabled()) {
                    LOGGER.debug(evt.Entity.GetType().getSimpleName() + "."
                            + annotation.incrementalProperty() + " = " + id);
                }*/
            /*}
            catch (IllegalAccessException e)
            {
                throw new HibernateException(e);
            }
            catch (InvocationTargetException e)
            {
                throw new HibernateException(e);
            }
        }
        else
        {
            /*if (LOGGER.isWarnEnabled()) {
                LOGGER.warn("value allready set! " + evt.Entity.GetType().getSimpleName() + "."
                        + annotation.incrementalProperty() + " == " + incrementalPropertyValue);
            }*/
            /*}
        }*/
            return false;
        }
    }
}